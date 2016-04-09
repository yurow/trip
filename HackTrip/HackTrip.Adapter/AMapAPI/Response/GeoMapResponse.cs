using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI.Response
{
    public class GeoMapResponse : ResponseBase
    {
        public List<string> geocodes { get; set; }
    }
}
