using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Extracts data that matches the JSON Key names
    /// </summary>
    public class WeatherRequest
    {
        public Coord coord { get; set; }        
        public List<WeatherGeneral> weather { get; set; }
        public WeatherDetails main { get; set; }
        public WindDetails wind { get; set; }
        public CloudDetails clouds { get; set; }

    }
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class WeatherGeneral
    {
        [JsonPropertyName("main")]
        public string CurrentWeather {  get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
    public class WeatherDetails
    {
        [JsonPropertyName("temp")]
        public double TemperatureCurrent { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike{ get; set; }

        [JsonPropertyName("temp_min")]
        public double TemperatureLow { get; set; }

        [JsonPropertyName("temp_max")]
        public double TemperatureHigh { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GroundLevel { get; set; }
    }
    public class WindDetails
    {
        [JsonPropertyName("speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("deg")]
        public double Degrees { get; set; }

        [JsonPropertyName("gust")]
        public double WindGust { get; set; }
    }
    public class CloudDetails
    {
        [JsonPropertyName("all")]
        public double CloudCoverage { get; set;}
    }
}