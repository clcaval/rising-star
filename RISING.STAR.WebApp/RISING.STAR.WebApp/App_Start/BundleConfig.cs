using System.Web;
using System.Web.Optimization;

namespace RISING.STAR.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/html5").Include(
                        "~/Scripts/html5shiv.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/lumino").Include(
                        "~/Scripts/lumino.glyphs.js"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-table.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/styles.css"));

            bundles.Add(new StyleBundle("~/Content/csssite").Include(
                      "~/Content/site.css"));
            
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/font").Include(
                       "~/Content/font-awesome.min.css",
                       "~/Content/themify-icons.css"));

        }
    }
}
