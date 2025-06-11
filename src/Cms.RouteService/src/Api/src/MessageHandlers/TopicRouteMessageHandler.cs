using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Services.Interfaces;
using Cms.Contracts.Routes;
using Wolverine.Attributes;

namespace Cms.RouteService.Api.MessageHandlers;

[WolverineHandler]
public sealed class TopicRouteMessageHandler(ITopicRouteService routeService)
{
    public async Task<TopicRouteCreateResponse?> HandleAsync(
        TopicRouteCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        return await routeService.CreateAsync(request, cancellationToken);
    }

    public async Task<TopicRouteGetByIdResponse?> HandleAsync(
        TopicRouteGetByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        return await routeService.GetByIdAsync(request, cancellationToken);
    }

    public async Task HandleAsync(
        TopicRouteDeleteRequest request,
        CancellationToken cancellationToken
    )
    {
        await routeService.DeleteAsync(request, cancellationToken);
    }
}
