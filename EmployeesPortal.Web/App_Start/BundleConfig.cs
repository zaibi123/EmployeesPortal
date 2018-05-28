using System.Web.Optimization;

namespace EmployeesPortal.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // ====================================================
            // Admin Content Bundles
            // ====================================================
            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/default/css/icons/icomoon/styles.css",
                   "~/Content/default/css/bootstrap.min.css",
                   "~/Content/default/css/core.css",
                   "~/Content/default/css/components.css",
                   "~/Content/default/css/colors.css",
                   "~/Content/default/css/style-admin.css"
           ));

            bundles.Add(new StyleBundle("~/Content/pagingcss").Include(
                    "~/Content/default/pagedlist.css"
            ));

            // ====================================================
            // Admin Script Bundles
            // ====================================================
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/default/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/default/js/core/libraries/bootstrap.min.js",
                      "~/Scripts/default/respond.js"));

            bundles.Add(new ScriptBundle("~/Scripts/corejs").Include(
                "~/Scripts/default/js/plugins/loaders/pace.min.js",
                "~/Scripts/default/js/plugins/loaders/blockui.min.js",
                "~/Scripts/default/js/plugins/notifications/pnotify.min.js",
                "~/Scripts/default/js/plugins/notifications/bootbox.min.js",
                "~/Scripts/default/js/plugins/notifications/sweet_alert.min.js",
                "~/Scripts/default/js/core/app.js",
                "~/Scripts/default/js/core/common.js",
                "~/Scripts/default/js/pages/components_notifications_pnotify.js",
                "~/Scripts/default/js/pages/components_modals.js",
                "~/Scripts/default/js/plugins/ui/moment/moment.min.js",
                "~/Scripts/default/js/plugins/pickers/daterangepicker.js",
                "~/Scripts/default/js/plugins/pickers/anytime.min.js",
                "~/Scripts/default/datepicker/jquery.datepick.js",
                "~/Scripts/handlebars-v{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/loginjs").Include(
                "~/Scripts/default/js/plugins/forms/styling/uniform.min.js",
                "~/Scripts/default/js/pages/login.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/dashboardjs").Include(
                "~/Scripts/default/js/plugins/visualization/d3/d3.min.js",
                "~/Scripts/default/js/plugins/visualization/d3/d3_tooltip.js",
                "~/Scripts/default/js/plugins/forms/styling/switchery.min.js",
                "~/Scripts/default/js/plugins/forms/styling/uniform.min.js",
                "~/Scripts/default/js/plugins/forms/selects/bootstrap_multiselect.js",
                "~/Scripts/default/js/plugins/ui/moment/moment.min.js",
                "~/Scripts/default/js/plugins/pickers/daterangepicker.js",
                "~/Scripts/default/js/pages/dashboard.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/datatables").Include(
                "~/Scripts/default/js/plugins/tables/datatables/datatables.min.js",
                "~/Scripts/default/js/plugins/forms/selects/select2.min.js",
                "~/Scripts/default/js/plugins/tables/datatables/extensions/buttons.min.js",
                "~/Scripts/default/js/plugins/tables/datatables/extensions/jszip/jszip.min.js",
                "~/Scripts/default/js/plugins/tables/datatables/extensions/pdfmake/pdfmake.min.js",
                "~/Scripts/default/js/plugins/tables/datatables/extensions/pdfmake/vfs_fonts.min.js",
                "~/Scripts/default/js/pages/datatables_extension_buttons_html5.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/ckeditor/ckeditor.js").Include(
                "~/Scripts/ckeditor/ckeditor.js"
            ));


            // Disables the minification of css.
            BundleTable.EnableOptimizations = false;
        }
    }
}
