using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mitawi.Models;
using Mitawi.Services;

namespace Mitawi.ViewModels
{
    public partial class HomeViewModel : MyBaseViewModel
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

        private async void OnGetWeatherData()
        {
            MyPlacemark = await _weatherDataService.GetPlacemarkAsync(false);
            Days = await _weatherDataService.GetDaysAsync(false);
            Hourlies = await _weatherDataService.GetHourliesAsync(false);

            // Get current time schedule
            MyHourly = Hourlies.ElementAt(0);
        }

        [RelayCommand]
        private void SelectedHourly(Hourly selectedHourly)
        {
            if (selectedHourly is not null)
            {
                MyHourly = selectedHourly;
            }
        }

        [RelayCommand]
        private async Task DailyForecast7Days()
        {
            await Task.Delay(150).ConfigureAwait(true);
            _navigationService.NavigateTo("HomeDetailPage", Days);
        }

    }
}
