using System.Threading.Tasks;
using Cms.Cli;
using Cms.Cli.Extensions;
using Cms.RouteService.Cli.Commands;
using Cms.RouteService.Infrastructure;

namespace Cms.RouteService.Cli;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = CliBuilder.CreateCliBuilder(args);

        builder.Services.AddCliInfrastructure(builder.Configuration);

        builder.Services.AddCommand<ApplyMigrationsCommand>("apply-migrations");

        await CliBuilder.RunCliAsync(builder);
    }
}
