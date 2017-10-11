using System;
using City_List_From_Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace City_List_From_Json_Unit_Test
{
    [TestClass]
    public class CityListFromJsonUnitTest
    {
        [TestMethod]
        public void CheckIfGetValidId()
        {
            var expected = 2643743;
            var actual = CityList.GetCityId("London", "GB");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckIfGetInvalidId()
        {
            var expected = -1;
            var actual = CityList.GetCityId("London", "UK");

            Assert.AreEqual(expected, actual);
        }
    }
}
