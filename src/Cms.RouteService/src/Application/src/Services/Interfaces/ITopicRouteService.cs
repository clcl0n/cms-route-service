using System.Threading;
using System.Threading.Tasks;
using Cms.Contracts.Routes;

namespace Cms.RouteService.Application.Services.Interfaces;

public interface ITopicRouteService
{
    Task<TopicRouteGetByIdResponse?> GetByIdAsync(
        TopicRouteGetByIdRequest request,
        CancellationToken cancellationToken
    );

    Task<TopicRouteCreateResponse> CreateAsync(
        TopicRouteCreateRequest request,
        CancellationToken cancellationToken
    );

    Task DeleteAsync(TopicRouteDeleteRequest request, CancellationToken cancellationToken);
}
