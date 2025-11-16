using Cms.RouteService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.RouteService.Infrastructure.Persistence.Configurations;

public class BaseRouteEntityConfiguration : IEntityTypeConfiguration<BaseRoute>
{
    public void Configure(EntityTypeBuilder<BaseRoute> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(x => x.Id);
    }
}
