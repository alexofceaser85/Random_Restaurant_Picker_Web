using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Random_Restaurant_Picker.Models {

    /**
     * The class manages the filters for finding a restaurant
     * 
     * @author Alex DeCesare
     * @version 24-Dec-2020
     **/

    public class RestaurantFilters {

        private Dictionary<String, String> queryFilters;
        private Dictionary<String, String> nonQueryFilters;

        private static readonly String TERM_KEY = "term";
        private static readonly String LOCATION_KEY = "location";
        private static readonly String RADIUS_KEY = "radius";
        private static readonly String FOOD_CATAGORIES_KEY = "categories";
        private static readonly String PRICE_KEY = "price";
        private static readonly String OPEN_NOW_KEY = "open_now";
        private static readonly String WHEELCHAIR_ACCESSIBLE_KEY = "wheelchair_accessible";
        private static readonly String ACCEPTS_RESERVATIONS_KEY = "reservation";
        private static readonly String NEW_RESTAURANTS_KEY = "hot_and_new";
        private static readonly String REVIEW_SCORE_KEY = "review_score";

        /**
         * The constructor for the filters.
         * 
         * @precondition none
         * @postcondition 
         *      this.queryFilters == new Dictionary<string, string>()
         *      this.nonQueryFilters == new Dictionary<string, string>()
         **/

        public RestaurantFilters() {
            this.queryFilters = new Dictionary<String, String>();
            this.nonQueryFilters = new Dictionary<String, String>();
        }

        /**
         * Adds the term as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/

        public void addTerm(String filterToAdd) {

            if(filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if(filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(TERM_KEY, filterToAdd);
        }

        /**
         * Removes the term as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeTerm() {
            this.queryFilters.Remove(TERM_KEY);
        }

        /**
         * Adds the location as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/

        public void addLocation(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(LOCATION_KEY, filterToAdd);
        }

        /**
         * Removes the location as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeLocation() {
            this.queryFilters.Remove(LOCATION_KEY);
        }

        /**
         * Adds the radius as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/

        public void addRadius(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(RADIUS_KEY, filterToAdd);
        }

        /**
         * Removes the radius as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeRadius() {
            this.queryFilters.Remove(RADIUS_KEY);
        }

        /**
         * Adds the food catagories as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addFoodCatagory(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(FOOD_CATAGORIES_KEY, filterToAdd);
        }

        /**
         * Removes the food catagory as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeFoodCatagory() {
            this.queryFilters.Remove(FOOD_CATAGORIES_KEY);
        }

        /**
         * Adds the price as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * The price could either be one value etc. 1, which is equal to $, or multiple values etc. 1,2,3 which is $,$$,$$$
         * Because of that the method checks if it needs to add onto the existing price values or make a new price key
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addPrice(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if(this.queryFilters.ContainsKey(PRICE_KEY)) {
                this.queryFilters[PRICE_KEY] += "," + filterToAdd;
            } else {
                this.queryFilters.Add(PRICE_KEY, filterToAdd);
            }
        }

        /**
         * Removes the price as a filter. Because the price could either be one value or multiple comma delimeted values
         * The method checks if it needs to remove the price as a part of the dictionary or just one value.
         * 
         * @precondition 
         *      priceToRemove           != null
         *      priceToRemove.isEmpty() == False
         * 
         * @postcondition none
         **/

        public void removePrice(String priceToRemove) {

            if (priceToRemove == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (priceToRemove.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if (this.queryFilters.ContainsKey(PRICE_KEY)) {
                String[] split_price_value = this.queryFilters[PRICE_KEY].Split(',');

                if (split_price_value.Length <= 1) {
                    this.queryFilters.Remove(PRICE_KEY);
                }
                else {
                    String updated_price_values = "";

                    foreach (String value in split_price_value) {
                        if (value != priceToRemove) {
                            updated_price_values += value + ",";
                        }
                    }

                    this.queryFilters[PRICE_KEY] = updated_price_values;
                }
            }
        }

        /**
         * Adds the open now boolean as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addOpenNow(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(OPEN_NOW_KEY, filterToAdd);
        }

        /**
         * Removes the open now as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeOpenNow() {
            this.queryFilters.Remove(OPEN_NOW_KEY);
        }

        /**
         * Adds the handicap accessible attribute as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addHandicapAccessible(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(WHEELCHAIR_ACCESSIBLE_KEY, filterToAdd);
        }

        /**
         * Removes the handicap accessible as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeHandicapAccessible() {
            this.queryFilters.Remove(WHEELCHAIR_ACCESSIBLE_KEY);
        }

        /**
         * Adds the accepts reservations attribute as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addAcceptsReservations(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(ACCEPTS_RESERVATIONS_KEY, filterToAdd);
        }

        /**
         * Removes the accepts reservations as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeAcceptsReservations() {
            this.queryFilters.Remove(ACCEPTS_RESERVATIONS_KEY);
        }

        /**
         * Adds the new restaurants attribute as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addNewRestaurants(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(NEW_RESTAURANTS_KEY, filterToAdd);
        }

        /**
         * Removes the new restaurants as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeAddNewRestaurants() {
            this.queryFilters.Remove(NEW_RESTAURANTS_KEY);
        }

        /**
         * Adds the review score as a filter. Because it is unable to be a parameter of the api query it is added to the nonQueryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addReviewScore(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.nonQueryFilters.Add(REVIEW_SCORE_KEY, filterToAdd);
        }

        /**
         * Removes the review score as a filter
         * 
         * @precondition none
         * @postcondition this.queryFilters.Count = this.queryFilters.Count - 1
         **/

        public void removeReviewScore() {
            this.queryFilters.Remove(REVIEW_SCORE_KEY);
        }

    }
}
 
 