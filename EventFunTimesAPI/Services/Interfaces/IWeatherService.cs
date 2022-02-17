using Projektarbete.Models;

namespace Projektarbete.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather();
    }
}