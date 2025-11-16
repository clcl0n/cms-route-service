using System;

namespace Cms.RouteService.Application.Contracts.Queries;

public sealed record PostRouteByIdQueryResult(Guid Id, string FullPath);