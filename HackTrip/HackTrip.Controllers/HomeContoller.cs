using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HackTrip.Controllers
{
    public class HomeContoller : Controller
    {
        public ActionResult Index()
        {
            return new EmptyResult();
        }
    }
}
