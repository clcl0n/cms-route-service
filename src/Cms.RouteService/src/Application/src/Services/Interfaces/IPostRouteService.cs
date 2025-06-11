using System.Threading;
using System.Threading.Tasks;
using Cms.Contracts.Routes;

namespace Cms.RouteService.Application.Services.Interfaces;

public interface IPostRouteService
{
    Task<PostRouteGetByIdResponse?> GetByIdAsync(
        PostRouteGetByIdRequest request,
        CancellationToken cancellationToken
    );

    Task<PostRouteCreateResponse> CreateAsync(
        PostRouteCreateRequest request,
        CancellationToken cancellationToken
    );

    Task DeleteAsync(PostRouteDeleteRequest request, CancellationToken cancellationToken);
}
