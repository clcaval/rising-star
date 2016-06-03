using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.Intervention
{
    public class InterventionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Intervention";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Intervention_default",
                "Intervention/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}