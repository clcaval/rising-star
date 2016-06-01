using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.OSI
{
    public class OSIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OSI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OSI_default",
                "OSI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}