using Claims;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using OnlyForMAUIClient;
using Shared;

namespace ClaimsMAUIClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.Claims(Standard.terminal.Software.ClaimsSoftware);
            builder.Services.Shared();
            builder.Services.OnlyForMAUIClient();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

           
            return builder.Build();
        }
    }
}