using System;

namespace Cms.RouteService.Domain.Entities;

public abstract class BaseEntity
{
    public required Guid Id { get; set; }
}
