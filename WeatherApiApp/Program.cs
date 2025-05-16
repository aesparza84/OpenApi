using ServiceInterfaces;
using ServiceLibrary;

namespace WeatherApiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IWeatherService, WeatherService>();


            var app = builder.Build();
            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
