namespace Mitawi;

public partial class App : Application
{
    public static NavigationService NavigationService { get; } = new NavigationService();
    public static IWeatherDataService WeatherDataServie { get; } = new WeatherDataService(new WeatherDataRepository());

    public App()
    {
        InitializeComponent();

        NavigationService.Configure(ViewNames.HomePage, typeof(HomePage));
        NavigationService.Configure(ViewNames.HomeDetailPage, typeof(HomeDetailPage));

        MainPage = new NavigationPage(new HomePage());
    }
}
