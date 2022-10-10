using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using OBJECTSOCIAL;
using OnlyForMAUIClient;
using Shared;

namespace OBJECTSOCIALMAUIClient;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        builder.Services.AddMauiBlazorWebView();
        builder.Services.OBJECTSOCIAL(Standard.terminal.Software.OBJECTSOCIALSoftware);
        builder.Services.Shared();
        builder.Services.OnlyForMAUIClient();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}