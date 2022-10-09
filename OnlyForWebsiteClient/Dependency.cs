using Microsoft.Extensions.DependencyInjection;
namespace OnlyForWebsiteClient;
public static class Dependency
{
    public static void OnlyForWebsiteClient(this IServiceCollection services)
    {
        services.AddScoped<Shared.IDevice, Device>();
    }
}