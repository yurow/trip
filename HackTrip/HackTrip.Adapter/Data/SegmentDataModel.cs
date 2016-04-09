using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace HackTrip.Adapter.Data
{
    public class SegmentDataModel
    {
        public long SegmentID { get; set; }
        public Nullable<byte> SegmentType { get; set; }
        public string Topic { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<long> CostSeconds { get; set; }
        public string Posi { get; set; }
        public Nullable<int> Index { get; set; }
        public long TripID { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public Nullable<decimal> Distance { get; set; }
    }
}
