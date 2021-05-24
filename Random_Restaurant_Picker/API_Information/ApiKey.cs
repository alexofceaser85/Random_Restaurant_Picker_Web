namespace Random_Restaurant_Picker.API_Information {

    /// <summary>
    /// The api key for the yelp api of the application
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    /// 21-May-2021
    /// </version>
    public class ApiKey {
        #region Data members

        private const string TheApiKey =
            "37xfA6m_1kEqknRMwJh0gEfCRGezIPDMDujNzeiqOZKK_axPgCp-cACK2xQof8VkPlzaVrfAW8dn8WOoOweI5pSNrlV-bhNqjWipnlBz0LpQ7Yt5jFn4N18UT4PrX3Yx";

        #endregion

        #region Constructors

        #endregion

        #region Methods

        /// <summary>
        /// Gets the API key
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>
        public static string GetApiKey() {
            return TheApiKey;
        }

        #endregion
    }
}