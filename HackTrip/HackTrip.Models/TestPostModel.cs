using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Models
{
    public class TestPostModel
    {
        public string StartSite { get; set; }
        public string CityId { get; set; }
        public List<string> SelectStateArray { get; set; }
    }
}
