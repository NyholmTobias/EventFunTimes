using Projektarbete.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace Projektarbete.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<Weather> GetWeather()
        {
            var url = "http://api.openweathermap.org/data/2.5/weather?id=2711537appid=48aef5938c023f547d4d3fb53e743d17&units=metric";
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

        private static Weather MapStringIntoWeather(string responseString)
        {
            XmlDocument doc = new();

            doc.LoadXml(responseString);

            var temp = doc.SelectSingleNode("//temperature").Attributes["value"].Value;
            var wind = doc.SelectSingleNode("//windSpeed").Attributes["mps"].Value;

            return new Weather { Temperature = double.Parse(temp), WindSpeed = double.Parse(wind) };
        }
    }
}
