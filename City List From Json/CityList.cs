using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace City_List_From_Json
{
    public static class CityList
    {
        private static List<CityEntry> _cityEntries;

        public static int GetCityId(string cityName, string countryCode)
        {
            ParseCityList();

            foreach (var cityEntry in _cityEntries)
            {
                if (cityEntry.Name.Equals(cityName) && cityEntry.Country.Equals(countryCode))
                {
                    return cityEntry.Id;
                }
            }

            return -1;
        }

        private static void ParseCityList()
        {
            string json = File.ReadAllText(@"Data\\city.list.json");
            _cityEntries = JsonConvert.DeserializeObject<List<CityEntry>>(json);
        }
    }

    
}
