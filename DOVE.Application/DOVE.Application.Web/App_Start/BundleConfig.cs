﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DOVE.Application.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jqgrid表格组件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/jqgrid/css").Include(
                        "~/Content/scripts/plugins/jqgrid/jqgrid.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/jqgrid/js").Include(
                       "~/Content/scripts/plugins/jqgrid/grid.locale-cn.js",
                       "~/Content/scripts/plugins/jqgrid/jqgrid.min.js"));
            //树形组件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/tree/css").Include(
                        "~/Content/scripts/plugins/tree/tree.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/tree/js").Include(
                       "~/Content/scripts/plugins/tree/tree.js"));
            //表单验证
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/validator/js").Include(
                      "~/Content/scripts/plugins/validator/validator.js"));
            ////日期控件
            //bundles.Add(new StyleBundle("~/Content/scripts/plugins/datetime/css").Include(
            //            "~/Content/scripts/plugins/datetime/pikaday.css"));
            //bundles.Add(new ScriptBundle("~/Content/scripts/plugins/datepicker/js").Include(
            //           "~/Content/scripts/plugins/datetime/pikaday.js"));
            //导向组件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/wizard/css").Include(
                        "~/Content/scripts/plugins/wizard/wizard.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/wizard/js").Include(
                       "~/Content/scripts/plugins/wizard/wizard.js" ));
            //DOVE
            bundles.Add(new StyleBundle("~/Content/styles/DOVE-ui.css").Include(
                        "~/Content/styles/DOVE-ui.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/js").Include(
                       "~/Content/scripts/utils/DOVE-ui.js",
                       "~/Content/scripts/utils/DOVE-form.js"));
            //DOVE Order
            //bundles.Add(new ScriptBundle("~/Content/scripts/plugins/printTable/js").Include(
            //    "~/Content/scripts/plugins/printTable/jquery.printTable.js"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/printTable/js").Include(
                "~/Content/scripts/plugins/printTable/jquery.jqprint-0.3.js"));

            //工作流
            bundles.Add(new StyleBundle("~/Content/styles/DOVE-flowall.css").Include(
            "~/Content/styles/DOVE-ckbox-radio.css",
            "~/Content/styles/DOVE-applayout.css",
            "~/Content/styles/DOVE-flow.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/flow/js").Include(
              "~/Content/scripts/utils/DOVE-applayout.js",
              "~/Content/scripts/plugins/flow-ui/flow.js",
              "~/Content/scripts/utils/DOVE-flowlayout.js"));


           



        }
    }
}