using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.EDM;

namespace project.Areas
{
    public class DefaultController : Controller
    {
        doctor_finderEntities df = new doctor_finderEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["email"];
            string pass = fc["password"];

            var userobj = df.patients.Where(u => u.email_id== email && u.password == pass).FirstOrDefault();
            if (userobj != null)
            {
                //cookies
                Session["UserId"] = userobj.patient_id;
                Session["UserName"] = userobj.f_name;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.loginerror = "Invalid Email or Password.";
            }
            return View();
        }
    }
}