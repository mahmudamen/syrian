using System.Web;
using System.Web.Optimization;

namespace Syrian
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include("~/Scripts/printThis-master/printThis.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/jqueryui/jquery-ui.min.js", "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js", "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/Assets").Include("~/Scripts/ivbw.js"));
            bundles.Add(new ScriptBundle("~/bundles/wAssets").Include("~/Scripts/ivbw.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js","~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                                      "~/Content/bootstrap.css",
                                      "~/Content/bootstrap-rtl.min.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/theme.css"
                      ));
        }
    }
}
