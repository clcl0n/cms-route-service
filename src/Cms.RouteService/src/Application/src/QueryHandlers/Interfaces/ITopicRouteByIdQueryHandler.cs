using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Contracts.Queries;

namespace Cms.RouteService.Application.QueryHandlers.Interfaces;

public interface ITopicRouteByIdQueryHandler
{
    Task<TopicRouteByIdQueryResult?> HandleAsync(TopicRouteByIdQuery command, CancellationToken cancellationToken);
}