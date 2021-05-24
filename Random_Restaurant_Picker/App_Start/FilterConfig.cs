using System.Web.Mvc;

namespace Random_Restaurant_Picker {

    /// <summary>
    /// The filter configurator for the application
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    /// 21-May-2021
    /// </version>
    public class FilterConfig {
        #region Methods


        /// <summary>
        /// Registers the global filters.
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
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}