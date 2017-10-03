using System;
using System.Net.Http;
using System.Net.Http.Headers;
using City_List_From_Json;
using Json_From_Web;
using Newtonsoft.Json;

namespace OpenWeatherMap_API_Wrapper.Current_Weather_Data
{
    public class CurrentWeather
    {
        public CurrentWeatherData WeatherData;

        public CurrentWeather(string cityName, string countryCode, string apiKey)
        {
            int id = CityList.GetCityId(cityName, countryCode);

            if (id != -1)
            {
                GetCurrentWeatherById(id, apiKey);
            }
        }

        public CurrentWeather(int id, string apiKey)
        {
            GetCurrentWeatherById(id, apiKey);
        }

        public CurrentWeather(string url)
        {
            var json = JsonHost.GetJson(url);

            WeatherData = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        private void GetCurrentWeatherById(int id, string apiKey)
        {
            var hostDetails = new HostDetails("http", "api.openweathermap.org", "data/2.5/weather");
            string query = "id=" + id + "&APPID=" + apiKey;

            var json = JsonHost.GetJson(hostDetails, query);

            WeatherData = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }
    }
}
