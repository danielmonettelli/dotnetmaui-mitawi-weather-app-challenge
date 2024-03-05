namespace Mitawi.Services;

public interface IWeatherDataService
{
    Task<WeatherData> GetAllWeatherDataAsync();
    Task<List<Hourly>> GetHourliesAsync();
    Task<List<Daily>> GetDaysAsync();
    Task<Placemark> GetPlacemarkAsync();
}
