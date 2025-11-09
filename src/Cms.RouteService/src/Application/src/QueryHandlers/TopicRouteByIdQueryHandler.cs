using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Contracts.Queries;
using Cms.RouteService.Application.QueryHandlers.Interfaces;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Application.QueryHandlers;

internal sealed class TopicRouteByIdQueryHandler(IUnitOfWork unitOfWork) : ITopicRouteByIdQueryHandler
{
    public async Task<TopicRouteByIdQueryResult?> HandleAsync(TopicRouteByIdQuery command, CancellationToken cancellationToken)
    {
        var route = await unitOfWork.TopicRouteRepository.GetByIdAsync(
            command.Id,
            cancellationToken
        );

        if (route is null)
        {
            return null;
        }

        return new TopicRouteByIdQueryResult(route.Id, route.Path);
    }
}