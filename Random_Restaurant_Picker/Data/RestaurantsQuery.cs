using System;
using System.Net;
using System.Web.WebPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Random_Restaurant_Picker.API_Information;
using Random_Restaurant_Picker.Models;
using WebGrease.Css.Visitor;

namespace Random_Restaurant_Picker.Data {

    /// <summary>
    /// This class holds the methods to query an API for restaurant information
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    /// 29-December-2020
    /// </version>
    public class RestaurantsQuery {
        #region Data members

        private readonly RestaurantFilters theFilters;
        private readonly RestaurantManager theManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantsQuery"/> class.
        /// </summary>
        ///
        /// <precondition>
        /// this.theFilters != null
        /// this.theManager != null
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theFilters = theFilters
        /// this.theManager = theManager
        /// </postcondition>
        /// 
        /// <param name="theFilters">The restaurant filters.</param>
        /// <param name="theManager">The restaurant manager.</param>
        /// 
        /// <exception cref="ArgumentException">
        /// </exception>
        public RestaurantsQuery(RestaurantFilters theFilters, RestaurantManager theManager) {
            this.theFilters = theFilters ?? throw new ArgumentException(ErrorMessages.ErrorMessages.FILTERS_TO_QUERY_CANNOT_BE_NULL);
            this.theManager = theManager ?? throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_MANAGER_FOR_QUERY_CANNOT_BE_NULL);
        }

        #endregion

        #region Methods


        /// <summary>
        /// Assembles the full query string.
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
        /// <returns>The complete query string</returns>
        public string AssembleQueryString() {
            const string queryBody = "https://api.yelp.com/v3/businesses/search?";

            const string filtersSeparator = "&";
            var filtersQuery = "";
            var filterCounter = 0;

            foreach (var key in this.theFilters.GetQueryFilters().Keys) {
                if (filterCounter == 0) {
                    filtersQuery += key + "=" + theFilters.GetQueryFilters()[key];
                }
                else {
                    filtersQuery += filtersSeparator + key + "=" + this.theFilters.GetQueryFilters()[key];
                }

                filterCounter++;
            }

            return queryBody + filtersQuery;
        }

        /// <summary>
        /// Queries the data source for restaurant data
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        /// <postcondition>
        /// this.theManager.Size() != 0 IF there exists api data
        /// this.theManager.Size() == 0 IF there does not exist api data
        /// </postcondition>
        /// <returns>the populated restaurant manager, returns null if the url is not valid</returns>
        public JArray QueryRestaurants(string apiQueryUrl) {
            try {
                var client = new WebClient();
                client.Headers.Add("Authorization", "Bearer " + ApiKey.GetApiKey());
                string response = client.DownloadString(apiQueryUrl);
                var retrievedRestaurantData = (JObject) JsonConvert.DeserializeObject(response);
                return (JArray) retrievedRestaurantData.GetValue("businesses");
            }
            catch (WebException) {
                return null;
            }
        }

        /// <summary>
        /// Populates the restaurant manager.
        /// </summary>
        ///
        /// <precondition>
        /// restaurantsData != null
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theManager.GetNumberOfRestaurants() MORE THAN 0
        /// </postcondition>
        /// 
        /// <param name="restaurantsData">The restaurants data.</param>

        public RestaurantManager PopulateRestaurants(JArray restaurantsData) {
            if (restaurantsData == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.CANNOT_POPULATE_NULL_RESTAURANT_DATA);
            }

            foreach (var restaurantData in restaurantsData) {
                var restaurantObjectData = (JObject) restaurantData;
                this.addRestaurant(restaurantObjectData, this.theManager);
            }

            return this.theManager;
        }

        private void addRestaurant(JObject restaurantObjectData, RestaurantManager theManager) {

            try {
                Restaurant restaurantToAdd = new Restaurant(
                    restaurantObjectData.GetValue("name").ToString(),
                    restaurantObjectData.GetValue("display_phone").ToString(),
                    restaurantObjectData.GetValue("price").ToString(),
                    this.AssembleLocationString(restaurantObjectData.GetValue("location")),
                    null,
                    restaurantObjectData.GetValue("distance").ToString(),
                    (double)restaurantObjectData.GetValue("rating"),
                    (int)restaurantObjectData.GetValue("review_count"),
                    restaurantObjectData.GetValue("url").ToString(),
                    restaurantObjectData.GetValue("image_url").ToString(),
                    restaurantObjectData.GetValue("id").ToString()
                );
                theManager.AddRestaurant(restaurantToAdd);
            }
            catch (NullReferenceException e) {
                Console.WriteLine(e.Message);
            }
        }

        private string AssembleLocationString(JToken location) {
            var locationObject = (JObject)location;

            string locationString = "";
            const string locationSeparator = ", ";

            foreach (string addressPortion in locationObject.GetValue("display_address")) {
                if (addressPortion != null && !addressPortion.IsEmpty()) {
                    locationString += addressPortion + locationSeparator;
                }
            }

            return locationString.Substring(0, locationString.Length - locationSeparator.Length);

        }

        #endregion
    }
}