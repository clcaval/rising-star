using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RISING.STAR.WebApp.Startup))]
namespace RISING.STAR.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
