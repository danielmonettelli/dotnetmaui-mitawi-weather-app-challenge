namespace Mitawi.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    private readonly IWeatherDataService _weatherDataService;

    [ObservableProperty]
    private bool isAnimationSkeleton;

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private List<Hourly> hourlies;

    [ObservableProperty]
    private Hourly myHourly;

    [ObservableProperty]
    private List<Daily> days;

    [ObservableProperty]
    private Placemark myPlacemark;

    public HomeViewModel(IWeatherDataService weatherDataService)
    {
        _weatherDataService = weatherDataService;

        WeatherDataFlow();
    }

    [RelayCommand]
    private async Task FullUpdate()
    {
        await WeatherDataFlow();
    }

    [RelayCommand]
    private async Task SelectedHourly(Hourly hourly)
    {
        if (hourly is not null)
        {
            IsAnimationSkeleton = true;

            MyHourly = hourly;

            await Task.Delay(1000).ContinueWith((t) =>
            {
                IsAnimationSkeleton = false;
            });
        }
    }

    [RelayCommand]
    private async Task DailyForecast7Days()
    {
        Dictionary<string, object> daysParameter = new()
        {
            [nameof(Days)] = Days
        };

        await Shell.Current.GoToAsync(
            state: nameof(HomeDetailPage),
            animate: true,
            parameters: daysParameter);
    }

    private async Task WeatherDataFlow()
    {
        IsLoading = true;

        var placemarkTask = _weatherDataService.GetPlacemarkAsync();
        var daysTask = _weatherDataService.GetDaysAsync();
        var hourliesTask = _weatherDataService.GetHourliesAsync();

        await Task.WhenAll(placemarkTask, daysTask, hourliesTask);

        MyPlacemark = await placemarkTask;
        Days = await daysTask;
        Hourlies = await hourliesTask;

        // Get current time schedule
        MyHourly = Hourlies.ElementAt(0);

        await Task.Delay(600).ContinueWith((t) =>
        {
            IsLoading = false;
        });
    }

}
