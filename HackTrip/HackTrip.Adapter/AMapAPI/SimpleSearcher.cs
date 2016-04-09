using HackTrip.Adapter.AMapAPI.Response;
using HackTrip.Adapter.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI
{
    /// <summary>
    /// 关键字搜索
    /// </summary>
    public class SimpleSearcher : QueryBase<SimpleSearcherResponse>
    {
        public SimpleSearcher(string keywords,string types,string city)
        {
            Push("keywords", keywords);
            Push("types", types);
            Push("city", city);
        }

        protected override string QueryURL
        {
            get
            {
                return "http://restapi.amap.com/v3/place/text";
            }
        }

    }
}
