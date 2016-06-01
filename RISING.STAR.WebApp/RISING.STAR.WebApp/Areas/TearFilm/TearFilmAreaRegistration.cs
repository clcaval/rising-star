using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.TearFilm
{
    public class TearFilmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TearFilm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TearFilm_default",
                "TearFilm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}