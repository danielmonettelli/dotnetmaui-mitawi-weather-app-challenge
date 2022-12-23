using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mitawi.Models;
using Mitawi.Services;

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
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                GetSkeletonList();

                IsBusy = true;

                MyPlacemark = await _weatherDataService.GetPlacemarkAsync(false);
                Days = await _weatherDataService.GetDaysAsync(false);
                Hourlies = await _weatherDataService.GetHourliesAsync(false);

                // Get current time schedule
                MyHourly = Hourlies.ElementAt(0);

                IsBusy = false;
            });
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
        private void FullUpdate(Hourly hourly)
        {
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                GetSkeletonList();

                IsBusy = true;

                Hourlies = await _weatherDataService.GetHourliesAsync(false);
                Days = await _weatherDataService.GetDaysAsync(false);

                IsBusy = false;
            });
        }

        [RelayCommand]
        private async Task DailyForecast7Days()
        {
            await Task.Delay(150).ConfigureAwait(true);
            _navigationService.NavigateTo("HomeDetailPage", Days);
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
