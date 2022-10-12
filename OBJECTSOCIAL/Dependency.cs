using Microsoft.Extensions.DependencyInjection;
namespace OBJECTSOCIAL;
public static class Dependency
{
    public static void OBJECTSOCIAL(this IServiceCollection services, Standard.terminal.Software software) {
        services.AddScoped(x => new Shared.Terminal
        {
            Entrance = Standard.terminal.Entrance.Business,
            Software = software, 
            IsPreview = true
        });
    }
}
