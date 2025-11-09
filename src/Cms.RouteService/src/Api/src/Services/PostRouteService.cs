using System;
using System.Threading.Tasks;
using Cms.Protos;
using Cms.RouteService.Application.Contracts.Commands;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.QueryHandlers.Interfaces;
using Cms.RouteService.Application.Contracts.Queries;
using Grpc.Core;

using static Cms.Protos.PostRouteService;
using Google.Protobuf.WellKnownTypes;

namespace Cms.RouteService.Api.Services;

public class PostRouteService(
    ICreatePostRouteCommandHandler createPostRouteCommandHandler,
    IPostRouteByIdQueryHandler postRouteByIdQueryHandler,
    IDeletePostRouteCommandHandler deletePostRouteCommandHandler) : PostRouteServiceBase
{
    public override async Task<PostRouteCreateResponse> Create(PostRouteCreateRequest request, ServerCallContext context)
    {
        var result = await createPostRouteCommandHandler.HandleAsync(new CreatePostRouteCommand(request.Slug), context.CancellationToken);

        return new PostRouteCreateResponse
        {
            Id = result.Id.ToString(),
            FullPath = result.FullPath
        };
    }

    public override async Task<PostRouteByIdResponse> GetById(PostRouteByIdRequest request, ServerCallContext context)
    {
        if (!Guid.TryParse(request.Id, out var id))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid GUID format for Id."));
        }

        var result = await postRouteByIdQueryHandler.HandleAsync(new PostRouteByIdQuery(id), context.CancellationToken)
            ?? throw new RpcException(new Status(StatusCode.NotFound, $"Post route with Id '{request.Id}' not found."));

        return new PostRouteByIdResponse
        {
            Id = result.Id.ToString(),
            FullPath = result.FullPath
        };
    }

    public override async Task<Empty> Delete(PostRouteDeleteRequest request, ServerCallContext context)
    {
        if (!Guid.TryParse(request.Id, out var id))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid GUID format for Id."));
        }

        await deletePostRouteCommandHandler.HandleAsync(new DeletePostRouteCommand(id), context.CancellationToken);

        return new Empty();
    }
}
