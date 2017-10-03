using System;
using System.Collections.Generic;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenWeatherMap_API_Wrapper.Current_Weather_Data;

namespace Current_Weather_Data_Test
{
    [TestClass]
    public class CurrentWeatherDataUnitTest
    {
        [TestMethod]
        public void SampleDataFromApiTest()
        {
            var currentWeather = new CurrentWeather("http://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b1b15e88fa797225412429c1c50c122a1");
            var actual = currentWeather.WeatherData;

            var expected = new CurrentWeatherData();
            expected.Coord = new Coordinates(-0.13, 51.51);
            expected.Weather = new List<Weather>
            {
                new Weather(300, "Drizzle", "light intensity drizzle", "09d")
            };
            expected.Base = "stations";
            expected.Main = new Main(280.32f, 1012, 81, 279.15f, 281.15f);
            expected.Visibility = 10000;
            expected.Wind = new Wind(4.1f, 80);
            expected.Clouds = new Clouds(90);
            expected.Dt = 1485789600;
            expected.Sys = new Sys(1, 5091, 0.0103f, "GB", 1485762037, 1485794875);
            expected.Id = 2643743;
            expected.Name = "London";
            expected.Cod = 200;

            actual.ShouldDeepEqual(expected);
        }
    }
}
