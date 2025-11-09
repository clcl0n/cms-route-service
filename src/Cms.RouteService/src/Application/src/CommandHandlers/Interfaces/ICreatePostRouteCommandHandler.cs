using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Contracts.Commands;

namespace Cms.RouteService.Application.CommandHandlers.Interfaces;

public interface ICreatePostRouteCommandHandler
{
    Task<CreatePostRouteCommandResult> HandleAsync(CreatePostRouteCommand command, CancellationToken cancellationToken);
}