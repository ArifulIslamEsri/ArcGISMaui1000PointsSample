using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;

namespace ArcGISMaui1000PointsSample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseArcGISRuntime()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        ArcGISRuntimeEnvironment.ApiKey = "";

        return builder.Build();
    }
}
