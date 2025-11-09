using System.Text.Json.Serialization;
using Cms.RouteService.Api.Extensions;
using Cms.RouteService.Api.Services;
using Cms.RouteService.Application;
using Cms.Shared.Setups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.RouteService.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ConfigureOtel();

        builder.Services.AddGrpc();

        builder.Services.ConfigureOtel();

        var healthChecksBuilder = builder.Services.AddHealthChecks();

        builder.Services.AddApplication(healthChecksBuilder, builder.Configuration);

        healthChecksBuilder.ConfigureHealthCheck(builder.Configuration);

        using var app = builder.Build();

        app.MapGrpcService<PostRouteService>();
        app.MapGrpcService<TopicRouteService>();

        app.UseHealthCheck();

        app.Run();
    }
}
