using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Models;
using ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ServiceLibrary
{

    //Api Docs: https://openweathermap.org/current
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory; //For making requests

        private readonly IConfiguration _configuration; //User Secrets

        public WeatherService(IHttpClientFactory fac, IConfiguration con)
        {
            _httpClientFactory = fac;
            _configuration = con;
        }


        public async Task<WeatherRequest> GetWeatherData(double lat, double lon)
        {
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                /*
                 
                //Create message
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_configuration["WeatherKey"]}");

                //Send, then store response
                HttpResponseMessage rawResponse = await client.SendAsync(request);

                //Read response 
                Stream stream =  await rawResponse.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(stream);
                string response = await reader.ReadToEndAsync();

                */

                string response = @"                          
                {
                   ""coord"": {
                      ""lon"": 7.367,
                      ""lat"": 45.133
                   },
                   ""weather"": [
                      {
                         ""id"": 501,
                         ""main"": ""Rain"",
                         ""description"": ""moderate rain"",
                         ""icon"": ""10d""
                      }
                   ],
                   ""base"": ""stations"",
                   ""main"": {
                      ""temp"": 284.2,
                      ""feels_like"": 282.93,
                      ""temp_min"": 283.06,
                      ""temp_max"": 286.82,
                      ""pressure"": 1021,
                      ""humidity"": 60,
                      ""sea_level"": 1021,
                      ""grnd_level"": 910
                   },
                   ""visibility"": 10000,
                   ""wind"": {
                      ""speed"": 4.09,
                      ""deg"": 121,
                      ""gust"": 3.47
                   },
                   ""rain"": {
                      ""1h"": 2.73
                   },
                   ""clouds"": {
                      ""all"": 83
                   },
                   ""dt"": 1726660758,
                   ""sys"": {
                      ""type"": 1,
                      ""id"": 6736,
                      ""country"": ""IT"",
                      ""sunrise"": 1726636384,
                      ""sunset"": 1726680975
                   },
                   ""timezone"": 7200,
                   ""id"": 3165523,
                   ""name"": ""Province of Turin"",
                   ""cod"": 200
                }                    
                                        ";
                
                try
                {
                    WeatherRequest data = JsonSerializer.Deserialize<WeatherRequest>(response);
                    return data;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                }
            }

            return null;
        }
    }
}
