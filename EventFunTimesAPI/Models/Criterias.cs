using EventFunTimesAPI.Services.Interfaces;

namespace EventFunTimesAPI.Models
{
    public class Criterias
    {
        public Criterias(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            Weather = _weatherService.GetWeather().Result;
            InsideEvent = SetEventType(Weather);
        }

        private readonly IWeatherService _weatherService;
        public Weather Weather { get; }
        public bool InsideEvent { get; set; }
        public DateTime Time = DateTime.Now;

        /// <summary>
        /// Sets the logic that desides if the application should request an inside or outside event.
        /// </summary>
        /// <returns>true=inside, false=outside</returns>
        private static bool SetEventType(Weather weather)
        {
            if (weather.Temperature < 5 && weather.WindSpeed > 5 || weather.WindSpeed > 10)
            {
                return true;
            }
            else return false;
        }
    }
}
