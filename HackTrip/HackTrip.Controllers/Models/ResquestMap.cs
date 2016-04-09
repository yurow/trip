using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackTrip.Controllers.Models
{
    public class ResquestMap
    {
        public string CityId { get; set; }
        public List<MapBase> List { get; set; }

    }
    public class MapPostModel
    {
        public string CityId { get; set; }
        public List<string> SelectStateArray { get; set; }
    }
    public class MapBase
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
    }
    public class MapDistance 
    {
        public double DistanceId { get; set; }

        public MapBase startItem { get; set; }
        public MapBase EndItem { get; set; }
    }
}