using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Random_Restaurant_Picker {

    /// <summary>
    /// The MvcApplication class for the application
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    ///  21-May-2021
    /// </version>
    /// <seealso cref="System.Web.HttpApplication" />
    public class MvcApplication : HttpApplication {
        #region Methods

        /// <summary>
        /// Starts the application
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #endregion
    }
}