using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS.Models;

namespace DBMS.Controllers
{
    public class HouseAdvertisementController : Controller
    {
        DBMSEntities2 db = new DBMSEntities2();


        // GET: HouseAdvertisement
        public ActionResult Index()
        {

            var model = db.House.ToList();
            return View(model);
        }

        public ActionResult HouseDetails(int id)
        {
            //var model = db.House.Find(id);
            var query = from a in db.House
                        where a.House_ID == id
                        select a;
            var result = query.FirstOrDefault();
            return View("HouseDetails", result);
        }

        public ActionResult SendRequest(int current_seeker)
        {
            //var seeker_id = TempData["seeker_id2"];
            var owner_id = TempData["owner_id"];

            // changeInfo(Convert.ToInt32(seeker_id));
            // changeInfo(Convert.ToInt32(owner_id));
            Random _random = new Random();

            Request new_request = new Request();
            new_request.Seeker_ID = Convert.ToInt32(owner_id);
            new_request.Owner_ID = current_seeker;
            new_request.Ad_ID = _random.Next(0, 9999999);
            new_request.Request_Date = DateTime.Now;

            db.Request.Add(new_request);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}