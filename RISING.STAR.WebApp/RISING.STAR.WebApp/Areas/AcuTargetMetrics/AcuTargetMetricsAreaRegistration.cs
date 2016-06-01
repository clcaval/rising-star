using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.AcuTargetMetrics
{
    public class AcuTargetMetricsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AcuTargetMetrics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AcuTargetMetrics_default",
                "AcuTargetMetrics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}