using System;

namespace Cms.RouteService.Application.Contracts.Commands;

public sealed record DeleteTopicRouteCommand(Guid Id);