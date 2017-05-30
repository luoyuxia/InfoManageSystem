using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace InfoManageSystem.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/editable_table").Include("~/Content/bootstrap-table/src/bootstrap-table.css",
                "~/Content/bootstrap-table/src/bootstrap-editable.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/editable_table").
                Include(
                "~/Content/bootstrap-table/src/bootstrap-table.js",
                "~/Content/bootstrap-table/src/bootstrap-editable.js", "~/Content/bootstrap-table/src/extensions/editable/bootstrap-table-editable.js",
                "~/Content/bootstrap-table/src/ga.js"));



            bundles.Add(new StyleBundle("~/Content/bootstrap-table").Include(
                    "~/Content/bootstrap-table/bootstrap.min.css",
                    "~/Content/bootstrap-table/bootstrap-table.min.css",
                    "~/Content/bootstrap-table/bootstrap-editable.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-table").Include(
                "~/Content/bootstrap-table/jquery.min.js",
                "~/Content/bootstrap-table/bootstrap.min.js",
                "~/Content/bootstrap-table/bootstrap-editable.min.js",
                 "~/Content/bootstrap-table/bootstrap-table.min.js",
                 "~/Content/bootstrap-table/bootstrap-table-zh-CN.min.js",
                 "~/Content/bootstrap-table/bootstrap-table-editable.js"
                ));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datapicker").Include(
                "~/Content/css/bootstrap-datetimepicker.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-timepicker").Include(
                "~/Content/js/bootstrap-datetimepicker.min.js",
                "~/Content/js/bootstrap-datetimepicker.zh-CN.js"
                ));

            bundles.Add(new StyleBundle("~/Content/boostrap-select").Include(
                "~/Content/css/bootstrap-select.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select").Include(
                "~/Content/js/bootstrap-select.min.js",
                "~/Content/js/defaults-zh_CN.min.js"
                ));
        
        }
    }
}