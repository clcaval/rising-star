using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.TestingTreatment
{
    public class TestingTreatmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestingTreatment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TestingTreatment_default",
                "TestingTreatment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}