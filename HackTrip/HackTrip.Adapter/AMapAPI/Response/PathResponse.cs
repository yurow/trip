using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI.Response
{
    public class PathResponse : ResponseBase
    {
        public RouteEntity route { get; set; }
    }
}
