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

        /// <summary>
        /// Initializes this class with the current weather data by City Name
        /// </summary>
        /// <param name="cityName">The desired city</param>
        /// <param name="countryCode">The city's country code</param>
        /// <param name="apiKey">Your private API key</param>
        public CurrentWeather(string cityName, string countryCode, string apiKey)
        {
            int id = CityList.GetCityId(cityName, countryCode);
            
            GetCurrentWeatherById(id, apiKey);
        }

        /// <summary>
        /// Initializes this class with the current weather data by City ID
        /// </summary>
        /// <param name="id">The desired city ID</param>
        /// <param name="apiKey">Your private API key</param>
        public CurrentWeather(int id, string apiKey)
        {
            GetCurrentWeatherById(id, apiKey);
        }

        /// <summary>
        /// Initializes this class with the current weather data by Geographic Coordinates
        /// </summary>
        /// <param name="logitude">The logitude of the location</param>
        /// <param name="latitude">The latitude of the location</param>
        /// <param name="apiKey">Your private API key</param>
        public CurrentWeather(double logitude, double latitude, string apiKey)
        {
            GetCurrentWeatherByCoords(logitude, latitude, apiKey);
        }

        /// <summary>
        /// Initializes this class with the current weather data by Zipcode
        /// </summary>
        /// <param name="local">The local containing the zipcode and country code</param>
        /// <param name="apiKey">Your private API key</param>
        public CurrentWeather(Local local, string apiKey)
        {
            GetCurrentWeatherByZipcode(local, apiKey);
        }

        /// <summary>
        /// Initializes this class with a raw JSON call (not recommended for production)
        /// </summary>
        /// <param name="url">URL for API call</param>
        public CurrentWeather(string url)
        {
            var json = JsonHost.GetJson(url);

            _data = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        /// <summary>
        /// Checks if the current data is a valid call to the OpenWeatherMapAPI
        /// </summary>
        /// <returns>True if valid call</returns>
        public bool IsValid()
        {
            return _data.Cod == 200;
        }

        private void GetCurrentWeatherById(int id, string apiKey)
        {
            string query = "id=" + id + "&APPID=" + apiKey;

            GetWeatherData(query);
        }

        private void GetCurrentWeatherByCoords(double logitude, double latitude, string apiKey)
        {
            string query = "lat=" + latitude + "&lon=" + logitude + "&APPID=" + apiKey;

            GetWeatherData(query);
        }

        private void GetCurrentWeatherByZipcode(Local local, string apiKey)
        {
            string query = "zip=" + local.Zipcode + "," + local.CountryCode + "&APPID=" + apiKey;

            GetWeatherData(query);
        }

        private void GetWeatherData(string query)
        {
            var hostDetails = new HostDetails("http", "api.openweathermap.org", "data/2.5/weather");
            var json = JsonHost.GetJson(hostDetails, query);
            _data = JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        /// <summary>
        /// Wrapper for the Zipcode and Country Code
        /// </summary>
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
