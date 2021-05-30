using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS.Models;
using System.IO;

namespace DBMS.Controllers
{
    public class ImageUploadController : Controller
    {
       
        DBMSEntities2 db = new DBMSEntities2();
        [HttpGet]
        // GET: ImageUpload
        public ActionResult Index()
        {
            Picture pic = new Picture();
            return View(pic);
        }
        [HttpPost]
        public ActionResult Index(Picture ImageModel,HttpPostedFileBase ImageFile)
        {
            var db = new DBMSEntities2();
           /* if (ImageFile == null)
            {
                Response.Write("<script>alert('You have to share your picture  ')</script>");
                return View("Index");
                //  Block of code to try
            }*/

            ImageModel.unique_House = Convert.ToInt32(TempData["unique_House"]);
            ImageModel.Picture_Names = DateTime.Now.ToString("yymmssfff");
           
            ImageModel.Picture1 = new byte[ImageFile.ContentLength];
            ImageFile.InputStream.Read(ImageModel.Picture1, 0, ImageFile.ContentLength);

            Random _random = new Random();
            ImageModel.ID = _random.Next(0, 9999999);
            db.Picture.Add(ImageModel);
            db.SaveChanges();


           
            
            return View("../HomePage/Index",ImageModel);
        }
       
        [HttpGet]
        public ActionResult GetAddressInfo(House house)
        {
            
            Adress adress = new Adress();
            
            return View(adress);
        }
        [HttpPost]
        public ActionResult GetAddressInfo(Adress adress)
        {
            
            adress.unique_House = Convert.ToInt32(TempData["unique_House"]);
            Random _random = new Random();
            adress.ID = _random.Next(0, 9999999);
            db.Adress.Add(adress);
            db.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult GetHouseInfo()
        {
            House house = new House();
            return View(house);
        }
        [HttpPost]
        public ActionResult GetHouseInfo(House house)
        {

            int ownerid=Convert.ToInt32(TempData["owner_id"]);
            var query7 = from a in db.Member
                         where a.Social_ID == ownerid
                         select a;
            Member member = query7.FirstOrDefault();

            
            db.Member.Remove(member);
            Random _random = new Random();
            house.unique_House = _random.Next(0, 9999999);
            house.Publish_Date = DateTime.Now;
            
            TempData["unique_House"] = house.unique_House;
            TempData.Keep("unique_House");
            db.House.Add(house);
            db.SaveChanges();

            var query6 = from a in db.House
                         where a.unique_House == house.unique_House
                         select a;
            House hm = query6.FirstOrDefault();
            member.House_ID = hm.House_ID;
            db.Member.Add(member);
            db.SaveChanges();
            return View("GetAddressInfo");
        }
    }
}