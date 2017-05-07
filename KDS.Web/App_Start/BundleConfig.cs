using System.Web;
using System.Web.Optimization;

namespace KDS.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kds").Include(
                      "~/Scripts/jquery.textarea.counter.js",
                      "~/Scripts/pnotify.custom.min.js",
                      "~/Scripts/jquery.bootstrap-touchspin.js",
                      "~/Scripts/ion.rangeSlider.js",
                      "~/Scripts/bootstrap3-typeahead.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js",
                      "~/Scripts/DataTables/dataTables.responsive.js",
                      "~/Scripts/DataTables/responsive.bootstrap.js",
                      "~/Scripts/core.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kds").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/awesome-bootstrap-checkbox.css",
                      "~/Content/pnotify.custom.min.css",
                      "~/Content/jquery.bootstrap-touchspin.css",
                      "~/Content/Slider/css/normalize.css",
                      "~/Content/Slider/css/ion.rangeSlider.css",
                      "~/Content/Slider/css/ion.rangeSlider.skinModern.css",
                      //"~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      //"~/Content/DataTables/css/responsive.dataTables.css",
                      "~/Content/DataTables/css/responsive.bootstrap.css"));
        }
    }
}
