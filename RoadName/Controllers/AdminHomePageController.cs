using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoadName.Controllers
{
    public class AdminHomePageController : Controller
    {
        // GET: AdminHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}