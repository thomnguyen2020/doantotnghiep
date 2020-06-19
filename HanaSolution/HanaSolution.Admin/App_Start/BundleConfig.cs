using System.Web;
using System.Web.Optimization;

namespace HanaSolution.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Styles/js").Include(
                      "~/Content/js/jquery-1.11.2.min.js",
                      "~/Content/js/jquery.easing.min.js",
                      "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                      "~/Content/plugins/pace/pace.min.js",
                      "~/Content/plugins/perfect-scrollbar/perfect-scrollbar.min.js",
                      "~/Content/plugins/viewport/viewportchecker.js",
                      "~/Content/plugins/datatables/js/jquery.dataTables.min.js",
                      "~/Content/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js",
                      "~/Content/plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js",
                      "~/Content/plugins/datatables/extensions/Responsive/bootstrap/3/dataTables.bootstrap.js",
                      "~/Content/plugins/messenger/js/messenger.min.js",
                      "~/Content/plugins/messenger/js/messenger-theme-future.js",
                      "~/Content/plugins/messenger/js/messenger-theme-flat.js",
                      "~/Content/js/messenger.js",
                      "~/Content/js/scripts.js",
                      "~/Content/plugins/sparkline-chart/jquery.sparkline.min.js",
                      "~/Content/js/chart-sparkline.js",
                      "~/Content/ckeditor/ckeditor.js",
                      "~/Content/ckfinder/ckfinder.js",
                      "~/Content/js/jquery-confirm.min.js"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/plugins/pace/pace-theme-flash.css",
                      "~/Content/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/plugins/bootstrap/css/bootstrap-theme.min.css",
                      "~/Content/fonts/font-awesome/css/font-awesome.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/plugins/perfect-scrollbar/perfect-scrollbar.css",
                      "~/Content/plugins/datatables/css/jquery.dataTables.css",
                       "~/Content/plugins/messenger/css/messenger.css",
                        "~/Content/plugins/messenger/css/messenger-theme-future.css",
                         "~/Content/plugins/messenger/css/messenger-theme-flat.css",
                      "~/Content/css/style.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/jquery-confirm.min.css"));
        }
    }
}
