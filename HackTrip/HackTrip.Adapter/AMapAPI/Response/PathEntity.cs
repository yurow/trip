using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI.Response
{
    public class PathEntity
    {
        public string distance { get; set; }
        public string duration { get; set; }
        public string strategy { get; set; }
        public string tolls { get; set; }
        public List<StepEntity> steps { get; set; }
    }
}
