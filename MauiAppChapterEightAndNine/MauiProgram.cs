using CommunityToolkit.Maui;
using MauiAppChapterEightAndNine.Renderers;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes.Android;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MauiAppChapterEightAndNine;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCompatibility()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureMauiHandlers((handlers) =>
            {
#if ANDROID
                handlers.AddCompatibilityRenderer(typeof(CustomEntry),
                    typeof(MauiAppChapterEightAndNine.Platforms.Android.Renderers.AndroidCustomEntry));
#endif

#if IOS
#endif
            })
            .RegisterViewModels()
            .RegisterViews();

        AppCenter.Start("android=07a38d4b-79e0-4cb9-8bc6-c752ba0c22fc;" +
                        "uwp={Your UWP App secret here};" +
                        "ios={Your iOS App secret here};" +
                        "macos={Your macOS App secret here};",
            typeof(Analytics), typeof(Crashes));
        return builder.Build();
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ViewModels.DataValidationViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<Views.DataValidationPage>();

        return mauiAppBuilder;
    }
}
