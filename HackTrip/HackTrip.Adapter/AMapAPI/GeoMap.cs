using HackTrip.Adapter.AMapAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI
{
    public class GeoMap : QueryBase<GeoMapResponse>
    {
        public GeoMap(string address,string city)
        {
            Push("address", address);
            Push("city", city);
        }

        protected override string QueryURL
        {
            get
            {
                return "http://restapi.amap.com/v3/geocode/geo";
            }
        }

    }
}
