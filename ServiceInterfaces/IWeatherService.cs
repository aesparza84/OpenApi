using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ServiceInterfaces
{
    public interface IWeatherService
    {
        public Task<WeatherRequest> GetWeatherData(double lat, double lon);
    }
}
