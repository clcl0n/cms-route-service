using Cms.RouteService.Application.Services;
using Cms.RouteService.Application.Services.Interfaces;
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

        services.AddScoped<IPostRouteService, PostRouteService>();
        services.AddScoped<ITopicRouteService, TopicRouteService>();
    }
}
