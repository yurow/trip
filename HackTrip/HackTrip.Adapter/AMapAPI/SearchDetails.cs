using HackTrip.Adapter.AMapAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI
{
    public class SearchDetails : QueryBase<SimpleSearcherResponse>
    {
        public SearchDetails(string id)
        {
            Push("id", id);
        }

        protected override string QueryURL
        {
            get
            {
                return "http://restapi.amap.com/v3/place/detail";
            }
        }

    }
}
