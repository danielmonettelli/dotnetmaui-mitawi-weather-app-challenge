namespace Mitawi.Utility
{
    public static class ViewModelLocator
    {
        public static HomeViewModel HomeViewModel { get; set; } = new HomeViewModel(App.WeatherDataServie, App.NavigationService);
        public static HomeDetailViewModel HomeDetailViewModel { get; set; } = new HomeDetailViewModel(App.NavigationService);
    }
}
