using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap_API_Wrapper.Current_Weather_Data
{
    public class CurrentWeatherData
    {
        /// <summary>
        /// City geo location coordinates
        /// </summary>
        public Coordinates Coord { get; set; }
        /// <summary>
        /// Weather condition codes
        /// </summary>
        public IList<Weather> Weather { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        public string Base { get; set; }
        /// <summary>
        /// Main weather data
        /// </summary>
        public Main Main { get; set; }
        /// <summary>
        /// Visibility, meter
        /// </summary>
        public int Visibility { get; set; }
        /// <summary>
        /// Wind data
        /// </summary>
        public Wind Wind { get; set; }
        /// <summary>
        /// Cloud data
        /// </summary>
        public Clouds Clouds { get; set; }
        /// <summary>
        /// Rain data
        /// </summary>
        public Rain Rain { get; set; }
        /// <summary>
        /// Snow data
        /// </summary>
        public Snow Snow { get; set; }
        /// <summary>
        /// Time of data calculation, unix, UTC
        /// </summary>
        public int Dt { get; set; }
        /// <summary>
        /// Additional details
        /// </summary>
        public Sys Sys { get; set; }
        /// <summary>
        /// City ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        public int Cod { get; set; }
    }

    public class Coordinates
    {
        /// <summary>
        /// City geo location, longitude
        /// </summary>
        public double Lon { get; set; }
        /// <summary>
        /// City geo location, latitude
        /// </summary>
        public double Lat { get; set; }

        public Coordinates(double lon, double lat)
        {
            Lon = lon;
            Lat = lat;
        }
    }

    public class Weather
    {
        /// <summary>
        /// Weather condition id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        public string Main { get; set; }
        /// <summary>
        /// Weather condition within the group
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Weather icon id
        /// </summary>
        public string Icon { get; set; }

        public Weather(int id, string main, string desc, string icon)
        {
            Id = id;
            Main = main;
            Description = desc;
            Icon = icon;
        }
    }

    public class Main
    {
        /// <summary>
        /// Temperature. 
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Temp { get; set; }
        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        /// </summary>
        public float Pressure { get; set; }
        /// <summary>
        /// Humidity, %
        /// </summary>
        public int Humidity { get; set; }
        /// <summary>
        /// Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). 
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Temp_min { get; set; }
        /// <summary>
        /// Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). 
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Temp_max { get; set; }
        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        public float Sea_level { get; set; }
        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        public float Grnd_level { get; set; }

        public Main(float temp, float pressure, int humidity, float temp_min, float temp_max, float sea_level, float grnd_level)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            Temp_min = temp_min;
            Temp_max = temp_max;
            Sea_level = sea_level;
            Grnd_level = grnd_level;
        }
    }

    public class Wind
    {
        /// <summary>
        /// Wind speed. 
        /// Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        public float Speed { get; set; }
        /// <summary>
        /// Wind direction, degrees (meteorological)
        /// </summary>
        public float Deg { get; set; }

        public Wind(float speed, float deg)
        {
            Speed = speed;
            Deg = deg;
        }
    }

    public class Clouds
    {
        /// <summary>
        /// Cloudiness, %
        /// </summary>
        public int All { get; set; }

        public Clouds(int all)
        {
            All = all;
        }
    }

    public class Rain
    {
        /// <summary>
        /// Rain volume for the last 3 hours
        /// </summary>
        public int _3H { get; set; }

        public Rain(int _3h)
        {
            _3H = _3h;
        }
    }

    public class Snow
    {
        /// <summary>
        /// Snow volume for the last 3 hours
        /// </summary>
        public int _3H { get; set; }

        public Snow(int _3h)
        {
            _3H = _3h;
        }
    }

    public class Sys
    {
        /// <summary>
        /// Internal parameter
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        public float Message { get; set; }
        /// <summary>
        /// Country code (GB, JP etc.)
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Sunrise time, unix, UTC
        /// </summary>
        public int Sunrise { get; set; }
        /// <summary>
        /// Sunset time, unix, UTC
        /// </summary>
        public int Sunset { get; set; }

        public Sys(int type, int id, float message, string country, int sunrise, int sunset)
        {
            Type = type;
            Id = id;
            Message = message;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
    }
}
