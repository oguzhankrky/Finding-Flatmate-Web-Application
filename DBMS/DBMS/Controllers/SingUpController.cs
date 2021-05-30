using DBMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LOGIN.Controllers
{
    
    public class SingUpController : Controller
    {

        
       // GET: SingUp 


       DBMSEntities2 db = new DBMSEntities2();
        
        public ActionResult Index()
        {
            
            return View();

        }

        public ActionResult Profil()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Singin()
        {
            TempData["Id"]  = "0";
            TempData["owner_id"] = "-1";
            return View();

        }
        [HttpPost]
        public ActionResult Singin(string EMail, string Password)
        {
            var EMailtemp = db.Member.Where(x => x.Email == EMail);

            if (db.Member.Any(anyObjectName => anyObjectName.Email == EMail
                                   && anyObjectName.Password == Password))
            {


                Member membertemp = db.Member.Find(EMail);
                TempData["message"] = "User :  "+ membertemp.Name+" "+membertemp.Surname;
                TempData["membertemp.Social_ID"] = membertemp.Social_ID;
                TempData["owner_id"] = membertemp.Social_ID;
                TempData["type"] = membertemp.Member_Type;
                TempData["Id"] = "1";
                return View("../HomePage/Index");

            }
            Response.Write("<script>alert('E-mail or Password is wrong. Please try again ')</script>");
            return View("Singin");
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View(new Member());
        }

        [HttpPost]
        public ActionResult Kaydet(Member member, HttpPostedFileBase ImageFile)
        {

            if (!ModelState.IsValid)
            {
                return View("Kaydet");
            }
            if (db.Member.Find(member.Email)==null) {
            if ((DateTime.Now.Year-member.Birthdate.Year )>17) {
            if (member.Member_Index == 0)
            {
               // if (ImageFile != null)
                //{
                    member.Member_picture = new byte[ImageFile.ContentLength];
                    ImageFile.InputStream.Read(member.Member_picture, 0, ImageFile.ContentLength);
                    //  Block of code to try
                //}

                //else
                //{
                   /* Response.Write("<script>alert('You have to share your picture  ')</script>");
                    return View("Kaydet");*/
                //}


                db.Member.Add(member);
            }
                }
                else
                {
                    Response.Write("<script>alert('User should be older  than 17 ')</script>");
                    return View("Kaydet");
                }
            }
            else
            {
                Response.Write("<script>alert('E-mail  was used  Please try with diffrent E-mail  again ')</script>");
                return View("Kaydet");
            }

            db.SaveChanges();
            return RedirectToAction("Singin");
        }
    }
}