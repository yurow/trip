using HackTrip.Adapter.AMapAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI
{
    /// <summary>
    /// 周边搜索
    /// </summary>
    public class AroundSearcher : QueryBase<SimpleSearcherResponse>
    {
        public AroundSearcher(string location, string keywords, string types)
        {
            Push("location", location);
            Push("keywords", keywords);
            Push("city", types);
        }

        protected override string QueryURL
        {
            get
            {
                return "http://restapi.amap.com/v3/place/around";
            }
        }

    }
}
