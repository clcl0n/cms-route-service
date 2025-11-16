using System.Threading;
using System.Threading.Tasks;

namespace Cms.RouteService.Infrastructure.Services.Interfaces;

public interface IPersistenceService
{
    Task ApplyMigrationsAsync(CancellationToken cancellationToken);
}
