using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doctor_fonder.EDM;

namespace doctor_fonder.Areas.hospital.Controllers
{
    public class DefaultController : Controller
    {
        doctor_finderEntities3 df = new doctor_finderEntities3();
        // GET: hospital/Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            string email = fc["email"];
            string password = fc["password"];

            var userobj = df.hospitals.Where(u => u.email_id == email && u.password == password).FirstOrDefault();

            if (userobj != null)
            {
                Session["userid"] = userobj.hospital_id;
                Session["username"] = userobj.hospital_name;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.loginerror = "inavlid email or password";
            }
                return View();
        }

    }
}