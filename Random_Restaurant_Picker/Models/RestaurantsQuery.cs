using System;
using System.Net;
using System.Web.WebPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Random_Restaurant_Picker.API_Information;

namespace Random_Restaurant_Picker.Models {
    /**
     * This class holds the methods to query an API for restaurant information
     * 
     * @author Alex DeCesare
     * @version 29-December-2020
     */
    public class RestaurantsQuery {
        #region Data members

        private readonly apiKey API_KEY_CLASS;
        private readonly RestaurantFilters theFilters;
        private readonly RestaurantManager theManager;

        #endregion

        #region Constructors

        /**
         * The constructor for the restaurants query class
         * 
         * @precondition 
         * this.theFilters != null
         * this.theManager != null
         *      
         * @postcondition 
         * this.theFilters = theFilters
         * this.theManager = theManager
         * this.API_KEY_CLASS = new API_Key
         */
        public RestaurantsQuery(RestaurantFilters theFilters, RestaurantManager theManager) {
            if (theFilters == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTERS_TO_QUERY_CANNOT_BE_NULL);
            }

            if (theManager == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .RESTAURANT_MANAGER_FOR_QUERY_CANNOT_BE_NULL);
            }

            this.API_KEY_CLASS = new apiKey();
            this.theFilters = theFilters;
            this.theManager = theManager;
        }

        #endregion

        #region Methods

        /**
         * Queries the restaurants from the API and creates new restaurants from that query string
         * 
         * @precondition none
         * @postcondition none
         */
        public RestaurantManager queryRestaurantsAsync() {
            var apiQueryURL = this.assembleFiltersQueryString();
            JArray retreivedRestaurantData;
            try {
                retreivedRestaurantData = (JArray) this.queryRestaurantData(apiQueryURL).GetValue("businesses");
            }
            catch (WebException) {
                return null;
            }

            if (retreivedRestaurantData != null) {
                this.populateRestaurants(retreivedRestaurantData);
            }

            return this.theManager;
        }

        private string assembleFiltersQueryString() {
            var queryBody = "https://api.yelp.com/v3/businesses/search?";
            var filtersSeperator = "&";
            var filtersQuery = "";
            var filterCounter = 0;

            foreach (var key in this.theFilters.GetQueryFilters().Keys) {
                if (filterCounter == 0) {
                    filtersQuery += key + "=" + this.theFilters.GetQueryFilters()[key];
                }
                else {
                    filtersQuery += filtersSeperator + key + "=" + this.theFilters.GetQueryFilters()[key];
                }

                filterCounter++;
            }

            return queryBody + filtersQuery;
        }

        private JObject queryRestaurantData(string queryString) {
            try {
                var client = new WebClient();
                client.Headers.Add("Authorization", "Bearer " + this.API_KEY_CLASS.getAPIKey());
                var response = client.DownloadString(queryString);
                var retreivedRestaurantData = JsonConvert.DeserializeObject(response);
                return (JObject) retreivedRestaurantData;
            }
            catch (WebException) {
                throw new WebException();
            }
        }

        private void populateRestaurants(JArray restaurantsData) {
            for (var counter = 0; counter < restaurantsData.Count; counter++) {
                var restaurantData = (JObject) restaurantsData[counter];
                if (restaurantData != null) {
                    try {
                        var restaurantToAdd = new Restaurant(
                            restaurantData.GetValue("name").ToString(),
                            restaurantData.GetValue("price").ToString(),
                            this.assembleLocationString(restaurantData.GetValue("location")),
                            restaurantData.GetValue("display_phone").ToString(),
                            restaurantData.GetValue("distance").ToString(),
                            (double) restaurantData.GetValue("rating"),
                            (int) restaurantData.GetValue("review_count"),
                            restaurantData.GetValue("url").ToString(),
                            restaurantData.GetValue("image_url").ToString(),
                            restaurantData.GetValue("id").ToString()
                        );

                        this.theManager.addRestaurant(restaurantToAdd);
                    }
                    catch (NullReferenceException) {
                    }
                }
            }
        }

        private string assembleLocationString(JToken location) {
            var locationObject = (JObject) location;

            var locationString = "";
            var locationSeperator = ", ";

            if (locationObject.GetValue("display_address") != null) {
                foreach (string addressPortion in locationObject.GetValue("display_address")) {
                    if (addressPortion != null && !addressPortion.IsEmpty()) {
                        locationString += addressPortion + locationSeperator;
                    }
                }
            }

            var indexToRemoveTrailingComma = locationString.Length - locationSeperator.Length;

            if (indexToRemoveTrailingComma > 0) {
                return locationString.Substring(0, locationString.Length - locationSeperator.Length);
            }

            return null;
        }

        #endregion
    }
}