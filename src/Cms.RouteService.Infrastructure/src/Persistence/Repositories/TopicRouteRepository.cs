using System;
using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Infrastructure.Persistence.Repositories.Base;
using Cms.RouteService.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cms.RouteService.Infrastructure.Persistence.Repositories;

internal sealed class TopicRouteRepository(DbContext dbContext)
    : BaseRepository<TopicRoute>(dbContext),
        ITopicRouteRepository;
