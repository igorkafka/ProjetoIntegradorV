using System.Web;
using System.Web.Optimization;

namespace PizzaExpress
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           ;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery-ui-1.12.1.js", "~/Scripts/jquery-ui-1.12.1.min.js", "~/Scripts/jquery.datetimepicker.full.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*", "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/scriptdopedido").Include("~/Scripts/ScriptPedido.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", "~/Content/themes/base/jquery-ui", "~/Content/themes/base/jquery-ui.min.css" , "~/Content/themes/base/jquery.datetimepicker.min.css", "~/Content/themes/base/autocomplete.css", "~/Content/themes/base/datepicker.css" ,"~/Content/themes/base/theme.css"));
            bundles.Add(new StyleBundle("~/bundles/scripsdoprojeto").Include("~/Scripts/scriptsprojeto.js"));
            
        }
    }
}
