using System;
using System.Collections.Generic;
using System.IO;
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
            var actual = currentWeather.Data;

            var expected = new CurrentWeatherData();
            expected.Coord = new Coordinates(-0.13, 51.51);
            expected.Weather = new List<Weather>
            {
                new Weather(300, "Drizzle", "light intensity drizzle", "09d")
            };
            expected.Base = "stations";
            expected.Main = new Main(280.32f, 1012, 81, 279.15f, 281.15f, 0, 0);
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

        [TestMethod]
        public void GetDataByCityNameTest()
        {
            var currentWeather = new CurrentWeather("London", "GB", GetApiKey());
            var actual = currentWeather.Data;

            Assert.AreNotEqual(401, actual.Cod);
        }

        [TestMethod]
        public void GetDataByCityIdTest()
        {
            var currentWeather = new CurrentWeather(2643743, GetApiKey());
            var actual = currentWeather.Data;

            Assert.AreNotEqual(401, actual.Cod);
        }

        [TestMethod]
        public void GetDataByCityGeoraphicCoordsTest()
        {
            var currentWeather = new CurrentWeather(-0.12574, 51.50853, GetApiKey());
            var actual = currentWeather.Data;

            Assert.AreNotEqual(401, actual.Cod);
        }

        public void GetDataByCityZipCodeTest()
        {
            var currentWeather = new CurrentWeather(new CurrentWeather.Local("EC2M", "GB"), GetApiKey());
            var actual = currentWeather.Data;

            Assert.AreNotEqual(401, actual.Cod);
        }

        private string GetApiKey()
        {
            string key = File.ReadAllText("APIKey.txt");
            return key;
        }
    }
}
