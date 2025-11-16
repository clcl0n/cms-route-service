using Cms.RouteService.Infrastructure.Persistence.Repositories.Interfaces;

namespace Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    IPostRouteRepository PostRouteRepository { get; }

    ITopicRouteRepository TopicRouteRepository { get; }
}
