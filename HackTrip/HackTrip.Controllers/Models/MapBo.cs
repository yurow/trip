using HackTrip.Adapter.AMapAPI;
using HackTrip.Adapter.AMapAPI.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace HackTrip.Controllers.Models
{
    public class MapBo
    {
        private MapBo() { }
        private static object lockHelper = new object();
        private static MapBo _mapBo = null;

        public static MapBo Instance
        {
            get
            {
                if (_mapBo == null)
                {
                    lock (lockHelper)
                    {
                        if (_mapBo == null)
                        {
                            _mapBo = new MapBo();
                        }
                    }
                }
                return _mapBo;
            }
        }

        #region 精度纬度获取距离
        /// <summary>
        /// 精度纬度获取距离
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        public double GetDistanceUtil(double lat1, double lng1, double lat2, double lng2)
        {
            try
            {
                if (lat1 <= 0 || lng1 <= 0 || lat2 <= 0 || lng2 <= 0)
                    return 0;
                double d_EarthRadius = 6378.137;
                double radLat1 = Fun_Rad(lat1);
                double radLat2 = Fun_Rad(lat2);
                double radLat = Fun_Rad(lat1) - Fun_Rad(lat2);
                double radLng = Fun_Rad(lng1) - Fun_Rad(lng2);
                double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(radLat / 2), 2) +
                 Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(radLng / 2), 2)));
                s = s * d_EarthRadius;
                s = Math.Round(s * 10000, MidpointRounding.AwayFromZero) / 10000;
                return s;
            }
            catch (Exception e)
            {
                //log
            }
            return 0;
        }
        private double Fun_Rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        #endregion


        public Tuple<string, string> ParseString(string s)
        {
            XElement xelem = XElement.Parse(s);
            var status = xelem.Element("status");
            if (status == null) return Tuple.Create("0", "0");
            if (status.Value == "0") return Tuple.Create("0", "0");
            if (status.Value == "1")
            {
                var result = from item in xelem.Descendants("route").Descendants("paths").Descendants("path")
                             select Tuple.Create((Convert.ToDouble(item.Element("distance").Value) / 1000.00d).ToString(),
                                                  Math.Round(Convert.ToDouble(item.Element("duration").Value) / 60d, 0).ToString());
                return result.FirstOrDefault();
            }
            return Tuple.Create("0", "0");
        }
        public string ConvertWebResponseToString1(HttpWebResponse result)
        {


            var reader = new StreamReader(result.GetResponseStream());
            var s = reader.ReadToEnd();
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public double GetMinVDistance(string Lon1, string Lat1, string Lon2, string Lat2)
        {
            double distance = 0;
            try
            {
                var request = new DrivingPath("", "", "");
                PathResponse result = request.Query();
                var dic = new Dictionary<double, PathEntity>();
                distance= result.route.paths.Min(x => Convert.ToDouble(x.distance));
            }
            catch (Exception ex)
            {

            }


            return distance;
        }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<double, PathEntity> GetVDistance(string Lon1, string Lat1, string Lon2, string Lat2)
        {
            var dic = new Dictionary<double, PathEntity>();
            try
            {
                var request = new DrivingPath(Lon1 + Lat1, Lon2 + Lat2, "");
                PathResponse result = request.Query();
                

                result.route.paths.ForEach(x =>
                {
                    if (!dic.ContainsKey(Convert.ToDouble(x.distance) / 1000.00d))
                        dic.Add(Convert.ToDouble(x.distance) / 1000.00d,x);                   
                });
            }
            catch (Exception ex)
            {
                
            }


            return dic;
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, PosiEntity> GetSenicSpotInfoById(string Id)
        {
            var dic = new Dictionary<string, PosiEntity>();
            try
            {
                var request = new SearchDetails(Id);
                var result = request.Query();


                result.pois.ForEach(x =>
                {
                    if (!dic.ContainsKey(x.id))
                        dic.Add(x.id, x);
                });
            }
            catch (Exception ex)
            {

            }
            return dic;
        }
          /// <summary>
        /// 吃饭
        /// </summary>
        public Dictionary<long, PosiEntity> GetDinerInfoById(string location, string Id)
        {
            var dic = new Dictionary<long, PosiEntity>();
            try
            {
                var request = new AroundSearcher(location,Id,"");
                var result = request.Query();


                result.pois.ForEach(x =>
                {
                    if (!dic.ContainsKey(Convert.ToInt64(x.id)) && x.biz_type == "diner")
                        dic.Add(Convert.ToInt64(x.id), x);
                });
            }
            catch (Exception ex)
            {

            }
            return dic;
        }
        
    }
 
}