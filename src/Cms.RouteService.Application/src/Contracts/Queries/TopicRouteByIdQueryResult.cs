using System;

namespace Cms.RouteService.Application.Contracts.Queries;

public sealed record TopicRouteByIdQueryResult(Guid Id, string FullPath);