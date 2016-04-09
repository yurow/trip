using HackTrip.Adapter.AMapAPI;
using HackTrip.Controllers.Models;
using HackTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackTrip.Controllers.Controllers
{
    public class TripScheduleController : Controller
    {
        //
        // GET: /TripSchedule/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Search(string Id)
        {
            var list = new SearchDetails(Id).Query();
            return Json(list);
        }
        public JsonResult Search(TestPostModel model)
        {
            var list = new ScheduleBo().GetSort(model);
            return Json(list);
        }


    }
}
