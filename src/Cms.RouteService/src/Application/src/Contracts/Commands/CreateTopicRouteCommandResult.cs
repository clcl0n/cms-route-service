using System;

namespace Cms.RouteService.Application.Contracts.Commands;

public sealed record CreateTopicRouteCommandResult(Guid Id, string FullPath);
