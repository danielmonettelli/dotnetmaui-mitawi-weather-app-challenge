namespace Mitawi;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
        .UseFFImageLoading()
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("Roboto-Bold.ttf", "Roboto#700");
            fonts.AddFont("Roboto-Medium.ttf", "Roboto#500");
            fonts.AddFont("Roboto-Regular.ttf", "Roboto#400");
            fonts.AddFont("customfonticons.ttf", "CustomFontIcons");
        }).UseMauiCommunityToolkit();

        //RegisterAllServices
        RegisterServices(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        //Register Services
        services.AddSingleton<IWeatherDataService, WeatherDataService>();

        //Register ViewModels
        services.AddSingleton<WelcomeViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddTransient<HomeDetailViewModel>();

        //Register Views
        services.AddSingleton<WelcomePage>();

        services.AddSingleton<HomePageOrientation>();
        services.AddSingleton<HomePage>();

        services.AddTransient<HomeDetailPageOrientation>();
        services.AddTransient<HomeDetailPage>();
    }
}
