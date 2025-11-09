using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Contracts.Commands;

namespace Cms.RouteService.Application.CommandHandlers.Interfaces;

public interface ICreateTopicRouteCommandHandler
{
    Task<CreateTopicRouteCommandResult> HandleAsync(CreateTopicRouteCommand command, CancellationToken cancellationToken);
}