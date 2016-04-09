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
            ts.NewTrip(new TripDataModel() { Origin = "cde" });
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}
