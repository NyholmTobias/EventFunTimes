using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Net;

namespace EventFunTimesAPI.Services
{
    public class WeatherService : IWeatherService
    {
        /// <summary>
        /// Gets the current weather from openweathermap api
        /// </summary>
        /// <returns>returns the temperature and wind speed in Gothenburg.</returns>
        public async Task<Weather> GetWeather()
        {
            var url = "http://api.openweathermap.org/data/2.5/weather?id=2711537&APPID=48aef5938c023f547d4d3fb53e743d17&units=metric";
            try
            {
                WebClient client = new();
                return MapStringIntoWeather(client.DownloadString(url));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converts responseString into Weather object
        /// </summary>
        /// <param name="responseString"></param>
        /// <returns>Weather object</returns>
        /// Found help here https://stackoverflow.com/questions/39723128/converting-a-string-to-json-in-c-sharp
        private static Weather MapStringIntoWeather(string responseString)
        {
            dynamic json = JsonConvert.DeserializeObject(responseString);

            var temp = json["main"]["temp"];
            var wind = json["wind"]["speed"];

            return new Weather { Temperature = temp, WindSpeed = wind };
        }
    }
}
