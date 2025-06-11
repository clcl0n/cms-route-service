using System;
using Cms.RouteService.Infrastructure.Persistence.Repositories;
using Cms.RouteService.Infrastructure.Persistence.Repositories.Interfaces;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Infrastructure.Persistence.UnitOfWork;

internal sealed class UnitOfWork(RouteDbContext dbContext) : IUnitOfWork
{
    public IPostRouteRepository PostRouteRepository => _lazyPostRouteRepository.Value;

    public ITopicRouteRepository TopicRouteRepository => _lazyTopicRouteRepository.Value;

    private readonly Lazy<IPostRouteRepository> _lazyPostRouteRepository = new(
        () => new PostRouteRepository(dbContext)
    );

    private readonly Lazy<ITopicRouteRepository> _lazyTopicRouteRepository = new(
        () => new TopicRouteRepository(dbContext)
    );
}
