using Cms.RouteService.Api.Setups;
using Cms.RouteService.Api.Services;
using Cms.RouteService.Application;
using Cms.RouteService.Infrastructure;
using Cms.Shared.Setups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.RouteService.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication
            .CreateBuilder(args)
            .SetupBuilder();

        using var app = builder
            .Build()
            .SetupApplication();

        app.Run();
    }

    private static WebApplicationBuilder SetupBuilder(this WebApplicationBuilder builder)
    {
        builder.Logging.SetupOpenTelemetry();
        builder.Services.SetupOpenTelemetry();

        builder.Services.AddGrpc();

        var healthChecksBuilder = builder.Services.AddHealthChecks();

        healthChecksBuilder.SetupHealthCheck(builder.Configuration);

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(healthChecksBuilder, builder.Configuration);

        return builder;
    }

    private static WebApplication SetupApplication(this WebApplication app)
    {
        app.MapGrpcService<PostRouteService>();
        app.MapGrpcService<TopicRouteService>();

        app.UseHealthCheck();

        return app;
    }
}
