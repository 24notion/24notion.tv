using System.Web.Optimization;

namespace _24N.tv_Refresh
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle JQuery 
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            // Bootstrap file(s)
            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.css"));
            bundles.Add(new Bundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.bundle.js"));

            // Main css file(s)
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            // Bundle BootSideMenu
            bundles.Add(new ScriptBundle("~/bundles/bootsidemenu")
                .Include("~/Scripts/bootsidemenu.js"));
            bundles.Add(new StyleBundle("~/Content/bootsidemenu")
                .Include("~/Content/bootsidemenu.css"));

            bundles.Add(new ScriptBundle("~/bundles/masonry")
                .Include("~/Scripts/masonry-{version}.js")
                .Include("~/Scripts/imagesloaded-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/packery")
                .Include("~/Scripts/packery-{version}.js")
                .Include("~/Scripts/imagesloaded-{version}.js"));
        }
    }
}