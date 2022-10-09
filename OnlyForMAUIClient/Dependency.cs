using Microsoft.Extensions.DependencyInjection;
using Shared;
namespace OnlyForMAUIClient;
public static class Dependency
{
    public static void OnlyForMAUIClient(this IServiceCollection services)
    {
        services.AddScoped<IDevice, Device>();
    }
}