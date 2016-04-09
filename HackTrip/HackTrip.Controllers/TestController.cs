using HackTrip.Adapter.AMapAPI;
using HackTrip.Adapter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HackTrip.Controllers
{
    public class TestController : Controller
    {
        public ActionResult SearchKey()
        {
            SimpleSearcher ss = new SimpleSearcher("a", "", "北京");
            var res = ss.Query();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchAround()
        {
            AroundSearcher ss = new AroundSearcher("116.459287,39.895433", "", "");
            var res = ss.Query();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchDetails()
        {
            SearchDetails ss = new SearchDetails("B000A84420");
            var res = ss.Query();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DrivingPath()
        {
            DrivingPath ss = new DrivingPath("116.459287,39.895433", "116.350459,39.846094", "5");
            var res = ss.Query();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DrivingPath2()
        {
            DrivingPath ss = new DrivingPath("116.459287,39.895433", "116.350459,39.846094", "B000A84420", "BX10015497", "5");
            var res = ss.Query();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestDB()
        {
            TripScope ts = new TripScope();
            TripDataModel td = new TripDataModel();
            td.Origin = "ttt";
            td.Segments = new List<SegmentDataModel>();
            for (int i = 0; i < 10; i++)
            {
                td.Segments.Add(new SegmentDataModel() { Topic = "AAA", Index = i, SegmentType = (byte)i, StartTime = DateTime.Now });
            }
            var s = ts.NewTrip(td);
            return Json(new { success = s }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTrip(long tripid)
        {
            TripScope ts = new TripScope();
            var s = ts.GetTrip(tripid);
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLastTrip()
        {
            TripScope ts = new TripScope();
            var s = ts.GetLastTrip();
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}