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
            return await GetAsyncMethodFactory<WeatherData>(TypeMethod.GetAllWeatherDataAsync);
        }

        public async Task<List<Hourly>> GetHourliesAsync()
        {
            return await GetAsyncMethodFactory<List<Hourly>>(TypeMethod.GetHourliesAsync);
        }

        public async Task<List<Daily>> GetDaysAsync()
        {
            return await GetAsyncMethodFactory<List<Daily>>(TypeMethod.GetDaysAsync);
        }

        public async Task<Placemark> GetPlacemarkAsync()
        {
            Location location = await Geolocation.Default.GetLocationAsync();

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
            Placemark placemark = placemarks?.FirstOrDefault();
            return placemark;
        }

        public async Task<T> GetAsyncMethodFactory<T>(TypeMethod typeMethod) where T : class
        {
            Location location = await Geolocation.Default.GetLocationAsync();
            Uri url = new(GenerateRequestUri(APIConstants.OpenWeatherMapEndpoint, location.Latitude, location.Longitude));

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return GetDeserializedContent<T>(typeMethod, content);
            }

            return null;
        }

        public static T GetDeserializedContent<T>(TypeMethod typeMethod, string content) where T : class
        {
            switch (typeMethod)
            {
                case TypeMethod.GetAllWeatherDataAsync:
                    return JsonSerializer.Deserialize<WeatherData>(content) as T;
                case TypeMethod.GetHourliesAsync:
                    return JsonSerializer.Deserialize<WeatherData>(content).Hourly as T;
                case TypeMethod.GetDaysAsync:
                    return JsonSerializer.Deserialize<WeatherData>(content).Daily as T;
                default:
                    throw new ArgumentException($"Invalid method type: {typeMethod}");
            }
        }

    }

    public enum TypeMethod
    {
        GetAllWeatherDataAsync,
        GetHourliesAsync,
        GetDaysAsync
    }

}
