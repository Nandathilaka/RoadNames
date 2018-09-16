using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoadName.Controllers
{
    public class UserHomePageController : Controller
    {
        // GET: UserHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}