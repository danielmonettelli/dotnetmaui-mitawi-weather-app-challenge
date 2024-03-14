namespace Mitawi.Models;

public class WeatherData
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonPropertyName("timezone_offset")]
    public int Timezone_offset { get; set; }

    [JsonPropertyName("hourly")]
    public List<Hourly> Hourly { get; set; }

    [JsonPropertyName("daily")]
    public List<Daily> Daily { get; set; }
}

public class Weather
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("main")]
    public string Main { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class Hourly
{
    public bool IsAnimationSkeleton { get; set; }

    [JsonPropertyName("dt")]
    public long Dt { get; set; }

    [JsonPropertyName("temp")]
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double Feels_like { get; set; }

    [JsonPropertyName("pressure")]
    public int pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("dew_point")]
    public double Dew_point { get; set; }

    [JsonPropertyName("uvi")]
    public double Uvi { get; set; }

    [JsonPropertyName("clouds")]
    public int Clouds { get; set; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("wind_speed")]
    public double Wind_speed { get; set; }

    [JsonPropertyName("wind_deg")]
    public int Wind_deg { get; set; }

    [JsonPropertyName("wind_gust")]
    public double Wind_gust { get; set; }

    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }

    [JsonPropertyName("pop")]
    public double Pop { get; set; }
}

public class Temp
{
    [JsonPropertyName("day")]
    public double Day { get; set; }

    [JsonPropertyName("min")]
    public double Min { get; set; }

    [JsonPropertyName("max")]
    public double Max { get; set; }

    [JsonPropertyName("night")]
    public double Night { get; set; }

    [JsonPropertyName("eve")]
    public double Eve { get; set; }

    [JsonPropertyName("morn")]
    public double Morn { get; set; }
}

public class FeelsLike
{
    [JsonPropertyName("day")]
    public double Day { get; set; }

    [JsonPropertyName("night")]
    public double Night { get; set; }

    [JsonPropertyName("eve")]
    public double Eve { get; set; }

    [JsonPropertyName("morn")]
    public double Morn { get; set; }
}

public class Daily
{
    [JsonPropertyName("dt")]
    public long Dt { get; set; }

    [JsonPropertyName("sunrise")]
    public int Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public int Sunset { get; set; }

    [JsonPropertyName("moonrise")]
    public int Moonrise { get; set; }

    [JsonPropertyName("moonset")]
    public int Moonset { get; set; }

    [JsonPropertyName("moon_phase")]
    public double Moon_phase { get; set; }

    [JsonPropertyName("temp")]
    public Temp Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public FeelsLike Feels_like { get; set; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("dew_point")]
    public double Dew_point { get; set; }

    [JsonPropertyName("wind_speed")]
    public double Wind_speed { get; set; }

    [JsonPropertyName("wind_deg")]
    public int Wind_deg { get; set; }

    [JsonPropertyName("wind_gust")]
    public double Wind_gust { get; set; }

    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }

    [JsonPropertyName("clouds")]
    public int Clouds { get; set; }

    [JsonPropertyName("pop")]
    public double Pop { get; set; }

    [JsonPropertyName("uvi")]
    public double Uvi { get; set; }
}