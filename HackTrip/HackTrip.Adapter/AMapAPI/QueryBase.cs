using HackTrip.Adapter.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HackTrip.Adapter.AMapAPI
{
    public abstract class QueryBase<Response>
    {
        protected Dictionary<string,string> parms = new Dictionary<string, string>();
        private string lastURL;

        protected abstract string QueryURL
        {
            get;
        }

        public void Push(string key,string value)
        {
            if (parms.ContainsKey(key))
                return;
            parms.Add(key, value);
        }

        private void Initialize()
        {
            Push("key", APISetting.KEY);
            string url = QueryURL;
            StringBuilder sb = new StringBuilder(url);
            if (url.IndexOf('?') > 0)
            {
                if (url[url.Length - 1] != '&')
                {
                    sb.Append('&');
                }
            }
            else
            {
                sb.Append('?');
            }
            foreach (var item in parms)
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value);
                sb.Append('&');
            }
            lastURL = sb.ToString();
        }

        public Response Query()
        {
            Initialize();
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string reuslt = client.DownloadString(lastURL);
            Console.WriteLine(reuslt);
            return QueryMethod(reuslt);
        }

        protected virtual Response QueryMethod(string jsonCode)
        {
            return JsonTool.parse<Response>(jsonCode);
        }
    }
}
