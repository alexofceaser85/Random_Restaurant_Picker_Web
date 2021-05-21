using System.Web.Mvc;
using System.Web.Routing;

namespace Random_Restaurant_Picker {
    public class RouteConfig {
        #region Methods

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