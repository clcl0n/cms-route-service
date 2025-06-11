using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Infrastructure.Persistence.Repositories.Base;
using Cms.RouteService.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cms.RouteService.Infrastructure.Persistence.Repositories;

internal sealed class PostRouteRepository(DbContext dbContext)
    : BaseRepository<PostRoute>(dbContext),
        IPostRouteRepository;
