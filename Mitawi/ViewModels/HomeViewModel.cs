namespace Mitawi.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IWeatherDataService _weatherDataService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private List<Hourly> hourlies;

        [ObservableProperty]
        private Hourly myHourly;

        [ObservableProperty]
        private List<Daily> days;

        [ObservableProperty]
        private Placemark myPlacemark;

        public HomeViewModel(IWeatherDataService weatherDataService, INavigationService navigationService)
        {
            _weatherDataService = weatherDataService;
            _navigationService = navigationService;

            OnGetWeatherData();
        }

        private void OnGetWeatherData()
        {
            WeatherDataFlow();
        }

        [RelayCommand]
        private void FullUpdate()
        {
            WeatherDataFlow();
        }

        [RelayCommand]
        private void SelectedHourly(Hourly hourly)
        {
            if (hourly is not null)
            {
                IsBusy = true;

                Task.Delay(1000).ContinueWith((t) =>
                {
                    IsBusy = false;
                });

                MyHourly = hourly;
            }
        }

        [RelayCommand]
        private async Task DailyForecast7Days()
        {
            await Task.Delay(150).ConfigureAwait(true);
            _navigationService.NavigateTo("HomeDetailPage", Days);
        }

        private void WeatherDataFlow()
        {
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                GetSkeletonList();

                IsBusy = true;

                var placemarkTask = _weatherDataService.GetPlacemarkAsync(false);
                var daysTask = _weatherDataService.GetDaysAsync(false);
                var hourliesTask = _weatherDataService.GetHourliesAsync(false);

                await Task.WhenAll(placemarkTask, daysTask, hourliesTask);

                MyPlacemark = await placemarkTask;
                Days = await daysTask;
                Hourlies = await hourliesTask;

                // Get current time schedule
                MyHourly = Hourlies.ElementAt(0);

                IsBusy = false;
            });
        }

        private List<Hourly> GetSkeletonList()
        {
            Hourlies = new List<Hourly>()
            {
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true},
                new Hourly {IsBusy=true}
            };

            return Hourlies;
        }

    }
}
