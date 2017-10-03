using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap_API_Wrapper.Current_Weather_Data
{

    public class CurrentWeatherData
    {
        public Coordinates Coord { get; set; }
        public IList<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

        public Coordinates(double lon, double lat)
        {
            Lon = lon;
            Lat = lat;
        }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
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
        public float Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }

        public Main(float temp, int pressure, int humidity, float temp_min, float temp_max)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            Temp_min = temp_min;
            Temp_max = temp_max;
        }
    }

    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }

        public Wind(float speed, int deg)
        {
            Speed = speed;
            Deg = deg;
        }
    }

    public class Clouds
    {
        public int All { get; set; }

        public Clouds(int all)
        {
            All = all;
        }
    }

    public class Rain
    {
        public int _3H { get; set; }

        public Rain(int _3h)
        {
            _3H = _3h;
        }
    }

    public class Snow
    {
        public int _3H { get; set; }

        public Snow(int _3h)
        {
            _3H = _3h;
        }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public float Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
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
