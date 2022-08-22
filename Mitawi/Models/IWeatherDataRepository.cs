namespace Mitawi.Models
{
    public interface IWeatherDataRepository
    {
        Task<WeatherData> GetAllWeatherDataAsync();
        Task<List<Hourly>> GetHourliesAsync();
        Task<List<Daily>> GetDaysAsync();
        Task<Placemark> GetPlacemarkAsync();
    }
}
