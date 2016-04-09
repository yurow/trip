using HackTrip.Adapter.AMapAPI;
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
    }
}
