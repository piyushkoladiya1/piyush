using System.Web.Mvc;

namespace doctor_fonder.Areas.hospital
{
    public class hospitalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "hospital";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "hospital_default",
                "hospital/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}