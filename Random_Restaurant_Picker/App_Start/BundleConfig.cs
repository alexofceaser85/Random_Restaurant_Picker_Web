﻿using System.Web.Optimization;

namespace Random_Restaurant_Picker {
    public class BundleConfig {
        #region Methods

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }

        #endregion
    }
}