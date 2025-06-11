using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Infrastructure.Persistence;
using Cms.RouteService.Infrastructure.Services.Interfaces;

namespace Cms.RouteService.Infrastructure.Services;

internal sealed class PersistenceService(RouteDbContext dbContext) : IPersistenceService
{
    public Task ApplyMigrationsAsync(CancellationToken cancellationToken)
    {
        return dbContext.ApplyMigrations(cancellationToken);
    }
}
