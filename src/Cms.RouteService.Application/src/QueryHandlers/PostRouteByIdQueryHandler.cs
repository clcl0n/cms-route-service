using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Application.Contracts.Queries;
using Cms.RouteService.Application.QueryHandlers.Interfaces;
using Cms.RouteService.Infrastructure.Persistence.UnitOfWork.Interfaces;

namespace Cms.RouteService.Application.QueryHandlers;

internal sealed class PostRouteByIdQueryHandler(IUnitOfWork unitOfWork) : IPostRouteByIdQueryHandler
{
    public async Task<PostRouteByIdQueryResult?> HandleAsync(PostRouteByIdQuery command, CancellationToken cancellationToken)
    {
        var route = await unitOfWork.PostRouteRepository.GetByIdAsync(
            command.Id,
            cancellationToken
        );

        if (route is null)
        {
            return null;
        }

        return new PostRouteByIdQueryResult(route.Id, route.Path);
    }
}