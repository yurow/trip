using HackTrip.Adapter.AMapAPI.Response;
using HackTrip.Controllers.Models;
using HackTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackTrip.Controllers
{
    public partial class ScheduleBo
    {
        /// <summary>
        /// 最小行车距离
        /// </summary>
        /// <param name="Lon1"></param>
        /// <param name="Lat1"></param>
        /// <param name="Lon2"></param>
        /// <param name="Lat2"></param>
        /// <returns></returns>
        public double GetMinVDistance(string Lon1, string Lat1, string Lon2, string Lat2)
        {
            return MapBo.Instance.GetMinVDistance(Lon1, Lat1, Lon2, Lat2);
        }

        /// <summary>
        /// 行车juli
        /// </summary>
        /// <param name="Lon1"></param>
        /// <param name="Lat1"></param>
        /// <param name="Lon2"></param>
        /// <param name="Lat2"></param>
        /// <returns></returns>
        public Dictionary<double, PathEntity> GetVDistance(string Lon1, string Lat1, string Lon2, string Lat2)
        {
            return MapBo.Instance.GetVDistance(Lon1, Lat1, Lon2, Lat2);
        }
        public double GetDistanceUtil(double lat1, double lng1, double lat2, double lng2)
        {
            return MapBo.Instance.GetDistanceUtil(lat1, lng1, lat2, lng2);
        }
        public ResquestMap ExChangeEntity(TestPostModel model)
        {
            ResquestMap _resquest = new ResquestMap() { CityId= model.CityId};
            List<string> oldList;
            model.SelectStateArray.ForEach(x =>
            {
                oldList = x.Split(',').ToList();
                _resquest.List.Add(new MapBase() { Lat = oldList[0], Lon = oldList[1] });
            });
            return _resquest;

        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="_resquest"></param>
        /// <returns></returns>
        public Dictionary<double, MapBase> GetSort(TestPostModel model)
        {
            var dic = new Dictionary<double, MapBase>();
            var list = new List<MapDistance>();
            double distance = 0;

            var _resquest = ExChangeEntity(model);
            for (int i = 1; i < _resquest.List.Count; i++)
            {
                //minDistance = GetDistanceUtil(Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon), Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon));
               if(i>0)
               {
                   for (int j = i + 1; j < _resquest.List.Count; j++)
                   {
                       distance = GetDistanceUtil(Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon), Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon));
                       list.Add(new MapDistance()
                      {
                          DistanceId = distance,
                          startItem = new MapBase() { Lat = _resquest.List[i].Lat, Lon = _resquest.List[i].Lon },
                          EndItem = new MapBase { Lat = _resquest.List[j].Lat, Lon = _resquest.List[j].Lon }
                      });
                }
               }
            }
            /*
            排序
             */
            return dic;
            
             
        }

    }
}