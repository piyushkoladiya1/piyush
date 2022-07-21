using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doctorfinder1.EDM;

namespace doctorfinder1.Areas.user.Controllers
{
    public class DefaultController : Controller
    {
        doctor_finderEntities1 df = new doctor_finderEntities1();
        // GET: user/Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            string email = fc["email"];
            string password = fc["password"];

            var userobj = df.patients.Where(u => u.email_id == email && u.password == password).FirstOrDefault();
            if (userobj != null)
            {
                Session["userid"] = userobj.patient_id;
                Session["username"] = userobj.f_name;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.loginerror = "inavalid email id or password.";
            }
            return View();
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(patient obj)
        {
            df.patients.Add(obj);
            df.SaveChanges();
            return RedirectToAction("login");
        }

    }
}