using System.Threading;
using System.Threading.Tasks;
using Cms.Cli.Commands.Interfaces;
using Cms.RouteService.Infrastructure.Services.Interfaces;

namespace Cms.RouteService.Cli.Commands;

public class ApplyMigrationsCommand(IPersistenceService persistenceService) : ICommand
{
    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return persistenceService.ApplyMigrationsAsync(cancellationToken);
    }
}
