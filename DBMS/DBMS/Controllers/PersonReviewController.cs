using DBMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS.Controllers
{
    public class PersonReviewController : Controller
    {
        DBMSEntities2 db = new DBMSEntities2();


      
        // GET: PersonReview
        public ActionResult Index()
        {
            var model = db.Member.ToList();
            return View(model);
        }
       

        public ActionResult PersonDetails(int id)
        {
            var query = from a in db.Member
                        where a.Social_ID == id
                        select a;
            var result = query.FirstOrDefault();
            return View("PersonDetails", result);
        }

        public ActionResult SendRequest(int current_seeker)
        {
            //var seeker_id = TempData["seeker_id"];
            var owner_id = TempData["owner_id"];

           // changeInfo(Convert.ToInt32(seeker_id));
           // changeInfo(Convert.ToInt32(owner_id));
            Random _random = new Random();

            Request new_request = new Request();
            new_request.Seeker_ID = Convert.ToInt32(owner_id);
            new_request.Owner_ID = current_seeker;
            new_request.Ad_ID = _random.Next(0,9999999);
            new_request.Request_Date = DateTime.Now;

            db.Request.Add(new_request);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

       /* private void changeInfo(int user_id_int)
        {
            
            var query = from a in db.Member
                        where a.Social_ID == user_id_int
                        select a;
            Member mem = query.FirstOrDefault();
            db.Member.Remove(mem);
            db.SaveChanges();
            mem.Seek_ID = 1;
            db.Member.Add(mem);
            db.SaveChanges();

        }*/


    }
}