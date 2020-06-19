using System.Web;
using System.Web.Optimization;

namespace HanaSolution.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Styles/js").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/popper.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/waypoints.min.js",
                      "~/Content/js/jquery.easing.min.js",
                      "~/Content/js/owl.carousel.min.js",
                      "~/Content/js/jquery.animatedheadline.min.js",
                      "~/Content/js/jquery.counterup.min.js",
                      "~/Content/js/wow.min.js",
                      "~/Content/js/jarallax.min.js",
                      "~/Content/js/jarallax-video.min.js",
                      "~/Content/js/default/jquery.passwordstrength.js",
                      "~/Content/js/default/dark-mode-switch.js",
                      "~/Content/js/default/active.js",
                      "~/Content/js/script.js"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/lib/bootstrap/css/bootstrap.min.css",
                      "~/Content/css/normalize.css",
                      "~/Content/css/theme.css",
                      "~/Content/css/theme/themelibrary.css",
                      "~/Content/lib/slick/slick/slick.css",
                      "~/Content/lib/slick/slick/slick-theme.css",
                      "~/Content/css/bootstrap-datepicker.min.css",
                      "~/Content/lib/Magnific-Popup-master/dist/magnific-popup.css"));
        }
    }
}
