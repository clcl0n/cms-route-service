namespace Cms.RouteService.Domain.Entities;

public abstract class BaseRoute : BaseEntity
{
    public required string Path { get; set; }
}
