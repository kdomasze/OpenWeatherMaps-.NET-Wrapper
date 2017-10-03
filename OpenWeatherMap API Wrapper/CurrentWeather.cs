using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Json_From_Web;
using Newtonsoft.Json;

namespace OpenWeatherMap_API_Wrapper.Current_Weather_Data
{
    public class CurrentWeather
    {
        public CurrentWeatherData WeatherData;

        public CurrentWeather(string cityName, string countryCode, string apiKey)
        {
            var hostDetails = new HostDetails("http", "api.openweathermap.org", "data/2.5/weather");
            string query = "q=" + cityName + "," + countryCode + "&APPID=" + apiKey;

            var json = JsonHost.GetJson(hostDetails, query);

            WeatherData = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        public CurrentWeather(string url)
        {
            var json = JsonHost.GetJson(url);

            WeatherData = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }
    }
}
