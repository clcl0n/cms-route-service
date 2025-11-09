using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.Contracts.Commands;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Application.CommandHandlers;

internal sealed class DeleteTopicRouteCommandHandler(IUnitOfWork unitOfWork) : IDeleteTopicRouteCommandHandler
{
    public async Task HandleAsync(DeleteTopicRouteCommand command, CancellationToken cancellationToken)
    {
        await unitOfWork.TopicRouteRepository.DeleteAsync(command.Id, cancellationToken);
    }
}