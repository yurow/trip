using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.Data
{
    public class TripDataModel
    {
        public long TripId { get; set; }
        public string Topic { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string OriginPosi { get; set; }
        public string DestinationPosi { get; set; }
        public Nullable<System.DateTime> OriginTime { get; set; }
        public Nullable<System.DateTime> DestinationTime { get; set; }

        public List<SegmentDataModel> Segments { get; set; }
    }
}
