using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackTrip.Controllers.Models
{
    public class MapEntity
    {
        public long Id { get; set; }

        public long Lon { get; set; }
        public long Lat { get; set; }
        public long tag { get; set; }

        public long name { get; set; }
        public long type { get; set; }
        public long typecode { get; set; }
        public long biz_type { get; set; }
        public long address { get; set; }
        public long location { get; set; }
        public long tel { get; set; }
        public long postcode { get; set; }
        public long website { get; set; }

        public long pcode { get; set; }
        public long pname { get; set; }
        public long citycode { get; set; }
        public long cityname { get; set; }
        public long adcode { get; set; }
        public long adname { get; set; }
        public long gridcode { get; set; }
        public long distance { get; set; }
        
            
    }
}