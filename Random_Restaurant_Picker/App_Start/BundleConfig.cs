using System.Web.Optimization;

namespace Random_Restaurant_Picker {


    /// <summary>
    /// The bundle configurator of the application
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    /// 21-May-2021
    /// </version>
    public class BundleConfig {
        #region Methods

        /// <summary>
        /// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>
        /// 
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }

        #endregion
    }
}