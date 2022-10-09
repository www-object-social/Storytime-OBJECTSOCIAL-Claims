﻿using Claims;
using MauiApp1.Data;
using Microsoft.Extensions.Logging;
using OnlyForMAUIClient;
using Shared;
using Claims;
namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.Claims(Standart.terminal.Software.ClaimsSoftware);
            builder.Services.AddMauiBlazorWebView();
            builder.Services.Shared();
            builder.Services.OnlyForMAUIClient();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}