using NanoidDotNet;

namespace Cms.RouteService.Domain.Factories;

public static class RoutePathFactory
{
    public static string CreateWithPostfix(string slug)
    {
        var urlPostfix = Nanoid.Generate();

        return $"{slug}-{urlPostfix}";
    }

    public static string Create(string slug)
    {
        return slug;
    }
}
