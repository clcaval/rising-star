using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.Visiometrics
{
    public class VisiometricsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Visiometrics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Visiometrics_default",
                "Visiometrics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}