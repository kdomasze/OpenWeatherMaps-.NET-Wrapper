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
            var expected = 707860;
            var actual = CityList.GetCityId("Hurzuf", "UA");

            Assert.AreEqual(expected, actual);
        }
    }
}
