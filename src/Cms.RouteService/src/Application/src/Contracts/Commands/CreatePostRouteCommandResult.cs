using System;

namespace Cms.RouteService.Application.Contracts.Commands;

public sealed record CreatePostRouteCommandResult(Guid Id, string FullPath);
