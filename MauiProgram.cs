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

        ArcGISRuntimeEnvironment.ApiKey = "AAPTa_jIiDCXQdFuncbRDk6iGJA..ARaYO88pyTFCsJFIXD0hwonjQ7hKWOayFsN4vlv96NJ2Lc3PqjxyDi_6a7G4vuQC7UeKaIo7F8gi6at5NmWHxHvNZyRfXs6dTUlqAkziGchcZm9eeQQSt-g3-TdMHTjAdWKGtjwVzPPsQOoaJZYMukloiJqg7llFf2aIvU-8z410LfR89BhwzcHKKHSPSQPis8-CXm-KJP3lT-5BDYaQvMMjOkQyOpAIcyWYaK52x_v46pmfqmS_FDLluw..AT1_z0QOlC59";

        return builder.Build();
    }
}
