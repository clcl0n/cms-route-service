using System.Text.Json.Serialization;
using Cms.RouteService.Api.Extensions;
using Cms.RouteService.Application;
using Cms.RouteService.Infrastructure;
using Cms.Shared.Setups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

namespace Cms.RouteService.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ConfigureOtel();

        builder.Services.ConfigureOtel();

        var healthChecksBuilder = builder.Services.AddHealthChecks();

        builder.Services.AddApplication(healthChecksBuilder, builder.Configuration);

        builder
            .Services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(
                    // show enum value in swagger.
                    new JsonStringEnumConverter()
                );
            });

        builder.Services.SetupApiConfiguration(builder.Configuration);

        healthChecksBuilder.ConfigureHealthCheck(builder.Configuration);

        builder.Services.ConfigureWolverine(builder.Configuration);

        using var app = builder.Build();

        // app.UseExceptionHandler();

        app.UseHealthCheck();

        app.Run();
    }
}
