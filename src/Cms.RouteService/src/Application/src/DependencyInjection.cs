using Cms.RouteService.Application.CommandHandlers;
using Cms.RouteService.Application.CommandHandlers.Interfaces;
using Cms.RouteService.Application.QueryHandlers;
using Cms.RouteService.Application.QueryHandlers.Interfaces;
using Cms.RouteService.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.RouteService.Application;

public static class DependencyInjection
{
    public static void AddApplication(
        this IServiceCollection services,
        IHealthChecksBuilder healthChecksBuilder,
        IConfiguration configuration
    )
    {
        services.AddInfrastructure(healthChecksBuilder, configuration);

        // Command Handlers
        // Must be Scoped because they depend on IUnitOfWork which is Scoped
        services.AddScoped<ICreatePostRouteCommandHandler, CreatePostRouteCommandHandler>();
        services.AddScoped<IDeletePostRouteCommandHandler, DeletePostRouteCommandHandler>();
        services.AddScoped<ICreateTopicRouteCommandHandler, CreateTopicRouteCommandHandler>();
        services.AddScoped<IDeleteTopicRouteCommandHandler, DeleteTopicRouteCommandHandler>();

        // Query Handlers
        // Must be Scoped because they depend on IUnitOfWork which is Scoped
        services.AddScoped<IPostRouteByIdQueryHandler, PostRouteByIdQueryHandler>();
        services.AddScoped<ITopicRouteByIdQueryHandler, TopicRouteByIdQueryHandler>();
    }
}
