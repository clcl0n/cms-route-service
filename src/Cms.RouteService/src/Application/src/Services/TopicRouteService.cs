using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Services.Interfaces;
using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Domain.Factories;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;
using Cms.Contracts.Routes;

namespace Cms.RouteService.Application.Services;

internal sealed class TopicRouteService(IUnitOfWork unitOfWork) : ITopicRouteService
{
    public async Task<TopicRouteGetByIdResponse?> GetByIdAsync(
        TopicRouteGetByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        var route = await unitOfWork.TopicRouteRepository.GetByIdAsync(
            request.Id,
            cancellationToken
        );

        if (route is null)
        {
            return null;
        }

        return new TopicRouteGetByIdResponse(route.Id, route.Path);
    }

    public async Task<TopicRouteCreateResponse> CreateAsync(
        TopicRouteCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        var routeToCreate = new TopicRoute
        {
            Id = default,
            Path = RoutePathFactory.Create(request.Slug),
        };

        var createdRoute = await unitOfWork.TopicRouteRepository.InsertAsync(
            routeToCreate,
            cancellationToken
        );

        return new TopicRouteCreateResponse(createdRoute.Id, createdRoute.Path);
    }

    public async Task DeleteAsync(
        TopicRouteDeleteRequest request,
        CancellationToken cancellationToken
    )
    {
        await unitOfWork.TopicRouteRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
