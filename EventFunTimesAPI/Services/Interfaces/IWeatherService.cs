using EventFunTimesAPI.Models;

namespace EventFunTimesAPI.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather();
    }
}