using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doctor_fonder.EDM;

namespace doctor_fonder.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        doctor_finderEntities3 df = new  doctor_finderEntities3();
        // GET: admin/Default
        public ActionResult dashboard()
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

          var userobj=  df.admins.Where(u => u.email_id == email && u.password == password).FirstOrDefault();
            if (userobj != null)
            {
                Session["userid"] = userobj.admin_id;
                Session["username"] = userobj.f_name;
                return RedirectToAction("dashboard");
            }
            else
            {
                ViewBag.loginerror = "invalid email or password";
            }
            return View();
        }
    }
}