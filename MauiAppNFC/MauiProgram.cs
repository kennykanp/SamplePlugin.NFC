#if IOS
using MauiAppNFC.Interfaces;
using MauiAppNFC.Platforms;
#endif

using MauiAppNFC.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiAppNFC
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if IOS
            builder.Services.AddTransient<INfcService, NfcService>();
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<MainViewModel>();

            return builder.Build();
        }
    }
}
