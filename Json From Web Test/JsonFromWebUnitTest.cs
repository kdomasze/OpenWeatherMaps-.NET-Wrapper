using System;
using Json_From_Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Json_From_Web_Test
{
    [TestClass]
    public class JsonFromWebUnitTest
    {
        [TestMethod]
        public void ValidApiCallTest()
        {
            const string expected = @"{""coord"":{""lon"":-0.13,""lat"":51.51},""weather"":[{""id"":300,""main"":""Drizzle"",""description"":""light intensity drizzle"",""icon"":""09d""}],""base"":""stations"",""main"":{""temp"":280.32,""pressure"":1012,""humidity"":81,""temp_min"":279.15,""temp_max"":281.15},""visibility"":10000,""wind"":{""speed"":4.1,""deg"":80},""clouds"":{""all"":90},""dt"":1485789600,""sys"":{""type"":1,""id"":5091,""message"":0.0103,""country"":""GB"",""sunrise"":1485762037,""sunset"":1485794875},""id"":2643743,""name"":""London"",""cod"":200}";

            var hostDetails = new HostDetails("http", "samples.openweathermap.org", "data/2.5/weather");
            var query = "q=London,uk&appid=b1b15e88fa797225412429c1c50c122a1";

            string actual = JsonHost.GetJson(hostDetails, query);

            Assert.AreEqual(expected, actual);
        }
    }
}
