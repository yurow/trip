using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI.Response
{
    public class SimpleSearcherResponse : ResponseBase
    {
        public List<PosiEntity> pois { get; set; }

    }
}
