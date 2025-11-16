using System;
using System.Threading.Tasks;
using Cms.Protos;
using Cms.RouteService.Application.Contracts.Commands;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.QueryHandlers.Interfaces;
using Cms.RouteService.Application.Contracts.Queries;
using Grpc.Core;

using static Cms.Protos.TopicRouteService;
using Google.Protobuf.WellKnownTypes;

namespace Cms.RouteService.Api.Services;

public class TopicRouteService(
    ICreateTopicRouteCommandHandler createTopicRouteCommandHandler,
    ITopicRouteByIdQueryHandler TopicRouteByIdQueryHandler,
    IDeleteTopicRouteCommandHandler deleteTopicRouteCommandHandler) : TopicRouteServiceBase
{
    public override async Task<TopicRouteCreateResponse> Create(TopicRouteCreateRequest request, ServerCallContext context)
    {
        var result = await createTopicRouteCommandHandler.HandleAsync(new CreateTopicRouteCommand(request.Slug), context.CancellationToken);

        return new TopicRouteCreateResponse
        {
            Id = result.Id.ToString(),
            FullPath = result.FullPath
        };
    }

    public override async Task<TopicRouteByIdResponse> GetById(TopicRouteByIdRequest request, ServerCallContext context)
    {
        if (!Guid.TryParse(request.Id, out var id))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid GUID format for Id."));
        }

        var result = await TopicRouteByIdQueryHandler.HandleAsync(new TopicRouteByIdQuery(id), context.CancellationToken)
            ?? throw new RpcException(new Status(StatusCode.NotFound, $"Topic route with Id '{request.Id}' not found."));

        return new TopicRouteByIdResponse
        {
            Id = result.Id.ToString(),
            FullPath = result.FullPath
        };
    }

    public override async Task<Empty> Delete(TopicRouteDeleteRequest request, ServerCallContext context)
    {
        if (!Guid.TryParse(request.Id, out var id))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid GUID format for Id."));
        }

        await deleteTopicRouteCommandHandler.HandleAsync(new DeleteTopicRouteCommand(id), context.CancellationToken);

        return new Empty();
    }
}
