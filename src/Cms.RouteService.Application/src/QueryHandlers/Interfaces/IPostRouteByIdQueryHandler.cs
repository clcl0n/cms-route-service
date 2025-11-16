using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Contracts.Queries;

namespace Cms.RouteService.Application.QueryHandlers.Interfaces;

public interface IPostRouteByIdQueryHandler
{
    Task<PostRouteByIdQueryResult?> HandleAsync(PostRouteByIdQuery command, CancellationToken cancellationToken);
}