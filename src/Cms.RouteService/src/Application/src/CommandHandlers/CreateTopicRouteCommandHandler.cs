using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.Contracts.Commands;
using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Domain.Factories;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Application.CommandHandlers;

internal sealed class CreatePostRouteCommandHandler(IUnitOfWork unitOfWork) : ICreatePostRouteCommandHandler
{
    public async Task<CreatePostRouteCommandResult> HandleAsync(CreatePostRouteCommand command, CancellationToken cancellationToken)
    {
        var routeToCreate = new PostRoute
        {
            Id = default,
            Path = RoutePathFactory.CreateWithPostfix(command.Slug),
        };

        var createdRoute = await unitOfWork.PostRouteRepository.InsertAsync(
            routeToCreate,
            cancellationToken
        );

        return new CreatePostRouteCommandResult(createdRoute.Id, routeToCreate.Path);
    }
}