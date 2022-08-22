using CommunityToolkit.Maui;

namespace Mitawi;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("Roboto-Bold.ttf", "Roboto#700");
            fonts.AddFont("Roboto-Medium.ttf", "Roboto#500");
            fonts.AddFont("Roboto-Regular.ttf", "Roboto#400");
            fonts.AddFont("customfonticons.ttf", "CustomFontIcons");
        }).UseMauiCommunityToolkit();

        return builder.Build();
    }
}