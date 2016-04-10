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
            for (int i = 1; i < model.Count; i++)
            {
                var item = new List<SegmentDataModel>();
                int index = 0;
                MapBo.Instance.GetSenicSpotInfoById(model[i].EndItem.Lon + model[i].EndItem.Lat).Values.ToList().ForEach(m =>
                    {
                        item.Add(new SegmentDataModel() { Posi = m.location, Topic = m.name, Index = index, SegmentType = 1, Origin = m.name, StartTime = Convert.ToDateTime(Convert.ToSingle(DateTime.Now.AddDays(6).Date) + " 06:10:00").AddHours(i + 2), Distance = Convert.ToDecimal(model[i].DistanceId) });
                        
                    });
                List.Segments.AddRange(item);
            }
        
            return AddTripData(List);
        }
        //查询
        public TripDataModel GetTripData(long Id)
        {
            var result = new TripScope().GetTrip(Id);
            return result;
        }
        //查询
        public TripDataModel GetLastTrip()
        {
            var result = new TripScope().GetLastTrip();
            return result;
        }
        ////查询
        //public TripDataModel GetLastTrip(int test)
        //{
        //    var result = new TripDataModel() { Segments = new List<SegmentDataModel>() };
        //    result.Segments.Add(new SegmentDataModel() { Destination = "2", Index = 2, SegmentID = 10 });
        //    result.Segments.Add(new SegmentDataModel() { Destination = "2", Index = 1, SegmentID = 10 });
        //    result.Segments = result.Segments.OrderBy(x => x.Index).ToList();
        //    return result;
            
        //}
         
    }
}