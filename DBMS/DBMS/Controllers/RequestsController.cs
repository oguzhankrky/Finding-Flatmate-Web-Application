using DBMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS.Controllers
{
    public class RequestsController : Controller
    {
        public static int current_id = 0;
        public static Boolean flag = false;
        DBMSEntities2 db = new DBMSEntities2();

        public ActionResult Index(int id)
        {
            current_id = id;
            flag = false;
            var resultList = db.Request.SqlQuery("Select * from Request WHERE Owner_ID = " + id+" and Owner_ID <> Seeker_ID").ToList();

            ViewData["current_id"] = id;

            return View(resultList);
        }
        public ActionResult Index2(int id)
        {
            current_id = id;
            flag = true;
            var resultList = db.Request.SqlQuery("Select * from Request WHERE Seeker_ID = " + id + " and Owner_ID <> Seeker_ID").ToList();

            ViewData["current_id"] = id;

            return View(resultList);
        }

        public ActionResult Accept()
        {
            var req_id = Convert.ToInt32(TempData["req_id"]);
            
            Request req = db.Request.Find(req_id);
            db.Request.Remove(req);
            db.SaveChanges();
            req.Is_Accept = true;
            db.Request.Add(req);
            db.SaveChanges();
            if (!flag)
                return RedirectToAction("Index/"+ current_id);
            return RedirectToAction("Index2/" + current_id);
        }

        public ActionResult Reject()
        {

            var req_id = Convert.ToInt32(TempData["req_id"]);

            Request req = db.Request.Find(req_id);
            db.Request.Remove(req);
            db.SaveChanges();
            req.Is_Accept = false;
            db.Request.Add(req);
            db.SaveChanges();
            if (!flag)
                return RedirectToAction("Index/" + current_id);
            return RedirectToAction("Index2/" + current_id);
        }
    }
}