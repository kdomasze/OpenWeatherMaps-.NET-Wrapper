using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using City_List_From_Json;
using Json_From_Web;
using Newtonsoft.Json;

namespace OpenWeatherMap_API_Wrapper.Current_Weather_Data
{
    public class CurrentWeather
    {
        private CurrentWeatherData _data;

        public CurrentWeatherData Data { get { return _data; } }

        public CurrentWeather(string cityName, string countryCode, string apiKey)
        {
            int id = CityList.GetCityId(cityName, countryCode);
            
            GetCurrentWeatherById(id, apiKey);
        }

        public CurrentWeather(int id, string apiKey)
        {
            GetCurrentWeatherById(id, apiKey);
        }

        public CurrentWeather(double logitude, double latitude, string apiKey)
        {
            GetCurrentWeatherByCoords(logitude, latitude, apiKey);
        }

        public CurrentWeather(Local local, string apiKey)
        {
            GetCurrentWeatherByZipcode(local, apiKey);
        }

        public CurrentWeather(string url)
        {
            var json = JsonHost.GetJson(url);

            _data = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        public bool IsValid()
        {
            return _data.Cod == 200;
        }

        private void GetCurrentWeatherById(int id, string apiKey)
        {
            var hostDetails = new HostDetails("http", "api.openweathermap.org", "data/2.5/weather");
            string query = "id=" + id + "&APPID=" + apiKey;

            var json = JsonHost.GetJson(hostDetails, query);

            _data = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        private void GetCurrentWeatherByCoords(double logitude, double latitude, string apiKey)
        {
            var hostDetails = new HostDetails("http", "api.openweathermap.org", "data/2.5/weather");
            string query = "lat=" + latitude + "&lon=" + logitude + "&APPID=" + apiKey;

            var json = JsonHost.GetJson(hostDetails, query);

            _data = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        private void GetCurrentWeatherByZipcode(Local local, string apiKey)
        {
            var hostDetails = new HostDetails("http", "api.openweathermap.org", "data/2.5/weather");
            string query = "zip=" + local.Zipcode + "," + local.CountryCode + "&APPID=" + apiKey;

            var json = JsonHost.GetJson(hostDetails, query);

            _data = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        public struct Local
        {
            public string Zipcode;
            public string CountryCode;

            public Local(string zipcode, string countryCode)
            {
                Zipcode = zipcode;
                CountryCode = countryCode;
            }
        }
    }
}
