using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doctor_fonder.EDM;

namespace doctor_fonder.Areas.user.Controllers
{
    public class DefaultController : Controller
    {
        doctor_finderEntities3 df = new doctor_finderEntities3();
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

          var userobj=  df.patients.Where(u => u.email_id == email && u.password == password).FirstOrDefault();
            if (userobj != null)
            {
                Session["userid"] = userobj.patient_id;
                Session["username"] = userobj.f_name;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.loginerror = "invalid email or password";
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

        public ActionResult finddoctor()
        {
            return View(df.doctors.ToList());
        }
        [HttpGet]
        public ActionResult addapoitment()
        {
            fillstatus();
            fillhospital();
            ViewBag.user = Session["username"].ToString();

            return View();
        }
        [HttpPost]
        public ActionResult addapoitment(appoitment obj)
        {
            obj.appoitment_status = "pending";
            obj.patient_id = Convert.ToInt32(Session["userid"]);
            df.appoitments.Add(obj);
            df.SaveChanges();
            return RedirectToAction("successs");

        }
        void fillhospital()
        {
            var hospital = from h in df.hospitals
                           select new SelectListItem { Value = h.hospital_id.ToString(), Text = h.hospital_name };
            ViewBag.hospital = hospital.ToList();
        }
        void fillstatus()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Value = "pending", Text = "pending" });
            ViewBag.status = li;
        }
        void fillpatient()
        {
            var patient = from p in df.patients
                          select new SelectListItem { Value = p.patient_id.ToString(), Text = p.f_name };
            ViewBag.patient = patient.ToList();
        }
        public JsonResult getdoctorbyhospitalid(int id)
        {
            df.Configuration.ProxyCreationEnabled = false;
            var doctor = df.doctors.Where(d => d.hospital_id == id).ToList();
            return Json(doctor, JsonRequestBehavior.AllowGet);
        }

    }

}