using HackTrip.Adapter.AMapAPI;
using HackTrip.Adapter.AMapAPI.Response;
using HackTrip.Adapter.Data;
using HackTrip.Controllers.Models;
using HackTrip.Controllers.Models.WebBo;
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
            ResquestMap _resquest = new ResquestMap() { CityId = model.CityId };
            _resquest.List = new List<MapBase>();
            model.SelectStateArray.ForEach(x =>
            {
                _resquest.List.Add(new MapBase() { Lat = x.lat, Lon = x.lng });
            });
            return _resquest;

        }
        /// <summary>
        /// huo
        /// </summary>
        /// <param name="_resquest"></param>
        /// <returns></returns>
        public TripDataModel GetLastTrip()
        {
            return new TripDataBo().GetLastTrip();


        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="_resquest"></param>
        /// <returns></returns>
        public TripDataModel GetSort(TestPostModel model)
        {
            //var dic = new Dictionary<double, MapBase>();
            var list = new List<MapDistance>();
            list.Add(new MapDistance() { Id = model.StartSite.id, EndItem = new MapBase() { Lat = model.StartSite.lat, Lon = model.StartSite.lng } });
            var cache = new List<Point>();
            foreach (var item in model.SelectStateArray)
            {
                cache.Add(item);
            }
            var current = list[0];
            int count = cache.Count;
            for (int i = 0; i < count; i++)
            {
                current = GetNext(current, cache);
                list.Add(current);
                if(cache.Count < 1)
                {
                    break;
                }
            }


            //double distance = 0;

            //var _resquest = ExChangeEntity(model);
            //for (int i = 0; i < _resquest.List.Count; i++)
            //{
            //    //minDistance = GetDistanceUtil(Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon), Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon));
            //    for (int j = i + 1; j < _resquest.List.Count; j++)
            //    {
            //        distance = GetDistanceUtil(Convert.ToDouble(_resquest.List[i].Lat), Convert.ToDouble(_resquest.List[i].Lon), Convert.ToDouble(_resquest.List[j].Lat), Convert.ToDouble(_resquest.List[j].Lon));
            //        list.Add(new MapDistance()
            //        {
            //            DistanceId = distance,
            //            startItem = new MapBase() { Lat = _resquest.List[i].Lat, Lon = _resquest.List[i].Lon },
            //            EndItem = new MapBase { Lat = _resquest.List[j].Lat, Lon = _resquest.List[j].Lon }
            //        });
            //    }
            //}
            /*
            排序
             */

            return new TripDataBo().AddTripData(list);


        }

        private MapDistance GetNext(MapDistance current, List<Point> points)
        {
            List<MapDistance> list = new List<MapDistance>();
            foreach (var item in points)
            {
                DrivingPath dp = new DrivingPath(current.EndItem.Lon + "," + current.EndItem.Lat, item.lng + "," + item.lat, "5");
                var time = float.Parse(dp.Query().route.paths[0].duration);
                var query = dp.Query();
                var distance = double.Parse(query.route.paths[0].distance);
                list.Add(new MapDistance()
                {
                    DistanceId = distance,
                    startItem = new MapBase() { Lat = current.EndItem.Lat, Lon = current.EndItem.Lon },
                    Duration = time,
                    EndItem = new MapBase() { Lat = item.lat, Lon = item.lng },
                    Id = item.id
                });
            }
            list.Sort(new SortMapDistance());
            var first = list[0];
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].id == first.Id)
                    points.RemoveAt(i);
            }
            return first;
        }

        private class SortMapDistance : IComparer<MapDistance>
        {
            public int Compare(MapDistance x, MapDistance y)
            {
                if (x.DistanceId > y.DistanceId) { return 1; }
                else if (x.DistanceId == y.DistanceId) { return 0; }

                else { return -1; }
            }
        }

    }
}