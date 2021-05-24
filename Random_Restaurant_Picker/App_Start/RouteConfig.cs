using System.Web.Mvc;
using System.Web.Routing;

namespace Random_Restaurant_Picker {


    /// <summary>
    /// The route configurator of the application
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    /// 21-May-2021
    /// </version>
    public class RouteConfig {
        #region Methods

        /// <summary>
        /// Registers the routes.
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>
        /// <param name="routes">The routes.</param>

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }

        #endregion
    }
}