using Microsoft.Extensions.Logging;
using OBJECTSOCIAL;
namespace OBJECTSOCIALSoftware;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.Services.AddMauiBlazorWebView();
        builder.Services.OBJECTSOCIAL(Shared.terminal.Software.OBJECTSOCIALSoftware);
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}