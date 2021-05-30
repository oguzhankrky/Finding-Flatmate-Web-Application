using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS.Controllers
{
    public class HomePageController : Controller
    {    static int counterI = 0;
        // GET: HomePage
        public ActionResult Index()
        {
            if (counterI == 0) {TempData["Id"] = "0"; counterI++; }
            
      
            
            return View();
        }
    }
}