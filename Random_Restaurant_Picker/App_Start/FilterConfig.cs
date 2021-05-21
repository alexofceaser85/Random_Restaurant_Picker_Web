using System.Web.Mvc;

namespace Random_Restaurant_Picker {
    public class FilterConfig {
        #region Methods

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}