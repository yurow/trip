using HackTrip.Adapter.AMapAPI.Response;
using HackTrip.Adapter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackTrip.Controllers.Models.WebBo
{
    public class TripDataBo
    {
        public bool AddTripData(TripDataModel model)
        {

            var result = new TripScope().NewTrip( model);
            return result;
        }
        public bool AddTripData(Dictionary<double, MapBase> model)
        {
            
            var List = new TripDataModel() {
                Destination = ""
            };
            var result = AddTripData( model);
            return result;
        }
        //添加
        public bool AddTripData(List<MapDistance> model)
        {
            var List = new TripDataModel() { Origin = model.FirstOrDefault().EndItem.Lon + model.FirstOrDefault().EndItem.Lat };
            model.AsParallel().ForAll(x =>
                {
                    var item = new List<SegmentDataModel>();
                    int index = 0;
                    MapBo.Instance.GetSenicSpotInfoById(x.EndItem.Lon+x.EndItem.Lat).Values.ToList().ForEach(m =>
                        {
                            item.Add(new SegmentDataModel() { Posi = m.location, Topic = m.name, Index = index, SegmentType = 1, Origin = m.name, StartTime = Convert.ToDateTime(Convert.ToSingle(DateTime.Now.AddDays(6).Date) + " 08:10:00").AddHours(index + 2),Distance = Convert.ToDecimal(x.DistanceId) });
                            index =+ 1;
                        });
                });
            return AddTripData(List);
        }
        //查询
        public TripDataModel GetTripData(long Id)
        {
            var List = new TripDataModel();

            var result = new TripScope().GetTrip(Id);
            return result;
        }
         
    }
}