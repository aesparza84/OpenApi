using Models;
using ServiceInterfaces;
using ServiceLibrary;

namespace Testing
{
    public class UnitTest1
    {
        private readonly IWeatherService _weatherService;

        public UnitTest1()
        {
            _weatherService = new WeatherService();
        }


        [Fact]
        public void JsonReadsCorrectly()
        {
            //Arrange

            //Act
            WeatherRequest weatherRequest = _weatherService.GetWeatherData(0,0);


            //Assert
            Assert.Equal(weatherRequest.coord.lon, 7.367);

        }
    }
}