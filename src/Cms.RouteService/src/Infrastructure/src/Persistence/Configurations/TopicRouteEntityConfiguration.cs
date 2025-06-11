using Cms.RouteService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Cms.RouteService.Infrastructure.Persistence.Configurations;

public class TopicRouteEntityConfiguration : IEntityTypeConfiguration<TopicRoute>
{
    public void Configure(EntityTypeBuilder<TopicRoute> builder)
    {
        builder.ToTable("topic_route");

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator((_, _) => new GuidValueGenerator());
        builder.Property(x => x.Path).IsRequired();

        builder.HasIndex(x => x.Path).HasDatabaseName("IX_topic_route___path").IsUnique();
    }
}
