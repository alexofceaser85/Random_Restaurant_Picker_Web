using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Random_Restaurant_Picker.API_Information;

namespace Random_Restaurant_Picker.Models {

    /**
     * This class holds the methods to query an API for restaurant information
     * 
     * @author Alex DeCesare
     * @version 29-December-2020
     **/

    public class RestaurantsQuery {

        private API_Key API_KEY_CLASS;
        private RestaurantFilters theFilters;
        private RestaurantManager theManager;

        /**
         * The constructor for the restaurants query class
         * 
         * @precondition 
         *      this.theFilters != null
         *      this.theManager != null
         *      
         * @postcondition 
         *      this.theFilters = theFilters
         *      this.theManager = theManager
         *      this.API_KEY_CLASS = new API_Key
         **/

        public RestaurantsQuery(RestaurantFilters theFilters, RestaurantManager theManager) {

            if (theFilters == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTERS_TO_QUERY_CANNOT_BE_NULL);
            }
            if (theManager == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_MANAGER_FOR_QUERY_CANNOT_BE_NULL);
            }

            API_KEY_CLASS = new API_Key();
            this.theFilters = theFilters;
            this.theManager = theManager;
        }

        /**
         * Queries the restaurants from the API and creates new restaurants from that query string
         * 
         * @precondition none
         * @postcondition none
         **/

        public RestaurantManager queryRestaurantsAsync() {
            String apiQueryURL = assembleFiltersQueryString();
            JArray retreivedRestaurantData;
            try {
                retreivedRestaurantData = (JArray)queryRestaurantData(apiQueryURL).GetValue("businesses");
            } catch (WebException) {
                return null;
            }

            if (retreivedRestaurantData != null) {
                this.populateRestaurants(retreivedRestaurantData);
            }

            return this.theManager;
        }
        private String assembleFiltersQueryString() {

            String queryBody = "https://api.yelp.com/v3/businesses/search?";
            String filtersSeperator = "&";
            String filtersQuery = "";
            int filterCounter = 0;

            foreach (String key in this.theFilters.getQueryFilters().Keys) {
                if (filterCounter == 0) {
                    filtersQuery += key + "=" + this.theFilters.getQueryFilters()[key];
                }
                else {
                    filtersQuery += filtersSeperator + key + "=" + this.theFilters.getQueryFilters()[key];
                }

                filterCounter++;
            }

            return queryBody + filtersQuery;
        }

        private JObject queryRestaurantData(String queryString) {  
            try {
                WebClient client = new WebClient();
                client.Headers.Add("Authorization", "Bearer " + API_KEY_CLASS.getAPIKey());
                string response = client.DownloadString(queryString);
                var retreivedRestaurantData = JsonConvert.DeserializeObject(response);
                return (JObject)retreivedRestaurantData;
            } catch (WebException) {
                throw new WebException();
            }
        }

        private void populateRestaurants(JArray restaurantsData) {

            for(int counter = 0; counter < restaurantsData.Count; counter++) {
                JObject restaurantData = (JObject)restaurantsData[counter];
                if (restaurantData != null) {
                    try {
                        Restaurant restaurantToAdd = new Restaurant(
                            restaurantData.GetValue("name").ToString(),
                            restaurantData.GetValue("price").ToString(),
                            this.assembleLocationString(restaurantData.GetValue("location")),
                            restaurantData.GetValue("display_phone").ToString(),
                            restaurantData.GetValue("distance").ToString(),
                            (double)restaurantData.GetValue("rating"),
                            (int)restaurantData.GetValue("review_count"),
                            restaurantData.GetValue("url").ToString(),
                            restaurantData.GetValue("image_url").ToString(),
                            restaurantData.GetValue("id").ToString()
                        );

                        this.theManager.addRestaurant(restaurantToAdd);
                    } catch (NullReferenceException) {

                    }
                }
            }
        }

        private String assembleLocationString(JToken location) {
            JObject locationObject = (JObject) location;

            String locationString = "";
            String locationSeperator = ", ";

            if (locationObject.GetValue("display_address") != null) {
                foreach(String addressPortion in locationObject.GetValue("display_address")) {
                    if (addressPortion != null && !addressPortion.IsEmpty()) {
                        locationString += addressPortion + locationSeperator;
                    }
                }
            }

            int indexToRemoveTrailingComma = locationString.Length - locationSeperator.Length;

            if (indexToRemoveTrailingComma > 0) {
                return locationString.Substring(0, locationString.Length - locationSeperator.Length);
            } else {
                return null;
            }
        }
    }
}