using Claims;
using Microsoft.Extensions.Logging;
using OnlyForMAUIClient;
using Shared;
namespace ClaimsSoftware;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>(); ;
        builder.Services.Claims(Shared.terminal.Software.ClaimsSoftware);
        builder.Services.AddMauiBlazorWebView();
        builder.Services.Shared();
        builder.Services.OnlyForMAUIClient();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}