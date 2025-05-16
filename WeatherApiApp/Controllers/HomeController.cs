using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;

namespace WeatherApiApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService serv)
        {
            _weatherService = serv;
        }


        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("WeatherData")]
        public IActionResult GetData()
        {
            if (_weatherService != null)
                _weatherService.GetWeatherData(41.875562, -87.624421); //Chicago Coords


            return View();
        }
    }
}
