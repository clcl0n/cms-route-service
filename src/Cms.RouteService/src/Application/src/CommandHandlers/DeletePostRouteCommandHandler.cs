using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.Contracts.Commands;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Application.CommandHandlers;

internal sealed class DeletePostRouteCommandHandler(IUnitOfWork unitOfWork) : IDeletePostRouteCommandHandler
{
    public async Task HandleAsync(DeletePostRouteCommand command, CancellationToken cancellationToken)
    {
        await unitOfWork.PostRouteRepository.DeleteAsync(command.Id, cancellationToken);
    }
}