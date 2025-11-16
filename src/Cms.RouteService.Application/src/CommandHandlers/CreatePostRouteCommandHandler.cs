using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.Contracts.Commands;
using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Domain.Factories;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Application.CommandHandlers;

internal sealed class CreateTopicRouteCommandHandler(IUnitOfWork unitOfWork) : ICreateTopicRouteCommandHandler
{
    public async Task<CreateTopicRouteCommandResult> HandleAsync(CreateTopicRouteCommand command, CancellationToken cancellationToken)
    {
        var routeToCreate = new TopicRoute
        {
            Id = default,
            Path = RoutePathFactory.CreateWithPostfix(command.Slug),
        };

        var createdRoute = await unitOfWork.TopicRouteRepository.InsertAsync(
            routeToCreate,
            cancellationToken
        );

        return new CreateTopicRouteCommandResult(createdRoute.Id, routeToCreate.Path);
    }
}