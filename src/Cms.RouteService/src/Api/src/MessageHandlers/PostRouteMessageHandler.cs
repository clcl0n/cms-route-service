using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Services.Interfaces;
using Cms.Contracts.Routes;
using Wolverine.Attributes;

namespace Cms.RouteService.Api.MessageHandlers;

[WolverineHandler]
public sealed class PostRouteMessageHandler(IPostRouteService routeService)
{
    public async Task<PostRouteCreateResponse?> HandleAsync(
        PostRouteCreateRequest request,
        CancellationToken cancellationToken
    )
    {
        return await routeService.CreateAsync(request, cancellationToken);
    }

    public async Task<PostRouteGetByIdResponse?> HandleAsync(
        PostRouteGetByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        return await routeService.GetByIdAsync(request, cancellationToken);
    }

    public async Task HandleAsync(
        PostRouteDeleteRequest request,
        CancellationToken cancellationToken
    )
    {
        await routeService.DeleteAsync(request, cancellationToken);
    }
}
