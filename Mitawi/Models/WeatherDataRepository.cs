using Mitawi.Constants;
using System.Text.Json;

namespace Mitawi.Models
{
    public class WeatherDataRepository : IWeatherDataRepository
    {
        private readonly HttpClient _httpClient;

        private string GenerateRequestUri(string endpoint, double latitude, double longitude)
        {
            string requestUri = endpoint;
            requestUri += $"?lat={latitude}";
            requestUri += $"&lon={longitude}";
            requestUri += "&exclude=current,minutely,alerts&units=metric";
            requestUri += $"&appid={APIConstants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        public WeatherDataRepository()
        {
            _httpClient = new HttpClient();
        }
        public async Task<WeatherData> GetAllWeatherDataAsync()
        {
            Location location = await Geolocation.Default.GetLocationAsync();
            Uri url = new(GenerateRequestUri(APIConstants.OpenWeatherMapEndpoint, location.Latitude, location.Longitude));

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WeatherData>(content);
            }
            return null;
        }

        public async Task<List<Hourly>> GetHourliesAsync()
        {
            Location location = await Geolocation.Default.GetLocationAsync();
            Uri url = new(GenerateRequestUri(APIConstants.OpenWeatherMapEndpoint, location.Latitude, location.Longitude));

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WeatherData>(content).Hourly;
            }
            return null;
        }

        public async Task<List<Daily>> GetDaysAsync()
        {
            Location location = await Geolocation.Default.GetLocationAsync();
            Uri url = new(GenerateRequestUri(APIConstants.OpenWeatherMapEndpoint, location.Latitude, location.Longitude));

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WeatherData>(content).Daily;
            }
            return null;

        }

        public async Task<Placemark> GetPlacemarkAsync()
        {
            Location location = await Geolocation.Default.GetLocationAsync();

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
            Placemark placemark = placemarks?.FirstOrDefault();
            return placemark;
        }

    }
}
