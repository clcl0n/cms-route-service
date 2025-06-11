using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Services.Interfaces;
using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Domain.Factories;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;
using Cms.Contracts.Routes;

namespace Cms.RouteService.Application.Services;

internal sealed class PostRouteService(IUnitOfWork unitOfWork) : IPostRouteService
{
    public async Task<PostRouteGetByIdResponse?> GetByIdAsync(
        PostRouteGetByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        var route = await unitOfWork.PostRouteRepository.GetByIdAsync(
            request.Id,
            cancellationToken
        );

        if (route is null)
        {
            return null;
        }

        return new PostRouteGetByIdResponse(route.Id, route.Path);
    }

    public async Task<PostRouteCreateResponse> CreateAsync(
        PostRouteCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var routeToCreate = new PostRoute
        {
            Id = default,
            Path = RoutePathFactory.CreateWithPostfix(request.Slug),
        };

        var createdRoute = await unitOfWork.PostRouteRepository.InsertAsync(
            routeToCreate,
            cancellationToken
        );

        return new PostRouteCreateResponse(createdRoute.Id, routeToCreate.Path);
    }

    public async Task DeleteAsync(
        PostRouteDeleteRequest request,
        CancellationToken cancellationToken
    )
    {
        await unitOfWork.PostRouteRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
