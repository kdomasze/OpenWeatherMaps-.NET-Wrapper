using System;
using System.Collections.Generic;
using System.Text;

namespace City_List_From_Json
{
    internal class CityEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Coordinates Coord { get; set; }
    }

    internal class Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}
