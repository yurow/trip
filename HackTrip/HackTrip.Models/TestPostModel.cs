using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Models
{
    public class TestPostModel
    {
        public Point StartSite { get; set; }
        public string CityId { get; set; }
        public List<Point> SelectStateArray { get; set; }
    }

    public class Point
    {
        public string id { get; set; }
        public string lng { get; set; }
        public string lat { get; set; }
    }
}
