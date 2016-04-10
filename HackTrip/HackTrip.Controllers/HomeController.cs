﻿using HackTrip.Adapter.AMapAPI;
using HackTrip.Adapter.Data;
using HackTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HackTrip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestPost(TestPostModel model)
        {
            var list = new ScheduleBo().GetSort(model);
            //ResultModel r = new ResultModel() {  List = list};
            //TripScope ts = new TripScope();
            //var s = ts.GetLastTrip();
            return View(list);
        }    
    }
}
