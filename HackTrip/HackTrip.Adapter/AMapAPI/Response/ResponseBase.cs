using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI.Response
{
    public class ResponseBase
    {
        public string status { get; set; }
        public string count { get; set; }
        public string info { get; set; }
        public string infocode { get; set; }

    }
}
