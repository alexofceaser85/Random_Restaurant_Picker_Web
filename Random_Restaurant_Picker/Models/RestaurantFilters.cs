using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private static readonly String ATTRIBUTES_KEY = "attributes";
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
         * Gets the query filters dictionary
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the query filters dictionary
         **/

        public Dictionary<String, String> getQueryFilters() {
            return this.queryFilters;
        }

        /**
         * Gets the non query filters dictionary
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the non query filters dictionary
         **/

        public Dictionary<String, String> getNonQueryFilters() {
            return this.queryFilters;
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
            if (!verifyRadius(filterToAdd)) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RADIUS_TO_ADD_IS_NOT_IN_CORRECT_FORMAT);
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
            if (!verifyPrice(filterToAdd)) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.PRICE_TO_ADD_IS_NOT_IN_CORRECT_FORMAT);
            }

            if (this.queryFilters.ContainsKey(PRICE_KEY)) {

                List<String> splitPriceFilters = this.queryFilters[PRICE_KEY].Split(',').ToList();

                if (!splitPriceFilters.Contains(filterToAdd)) {
                    splitPriceFilters.Add(filterToAdd);
                    List<String> sortedPriceFilters = splitPriceFilters.OrderBy(q => q).ToList();

                    this.queryFilters[PRICE_KEY] = String.Join(",", sortedPriceFilters);
                }

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
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.PRICE_TO_REMOVE_CANNOT_BE_NULL);
            }
            if (priceToRemove.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.PRICE_TO_REMOVE_CANNOT_BE_EMPTY);
            }

            removeCommaSeperatedValues(PRICE_KEY, priceToRemove);
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
            if (!verifyBoolean(filterToAdd)) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.OPEN_NOW_IS_NOT_IN_CORRECT_FORMAT);
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
         * Adds the attributes as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
         * 
         * @precondition 
         *      filterToAdd           != null
         *      filterToAdd.isEmpty() == False
         *      
         * @postcondition
         *      this.queryFilters.Count == this.queryFilters.Count + 1
         **/
        public void addAttribute(String filterToAdd) {

            if (filterToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }
            if (filterToAdd.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }
            if (this.queryFilters.ContainsKey(ATTRIBUTES_KEY)) {

                String[] splitAttributes = this.queryFilters[ATTRIBUTES_KEY].Split(',');

                if(!splitAttributes.Contains(filterToAdd)) {
                    this.queryFilters[ATTRIBUTES_KEY] += "," + filterToAdd;
                }

            } else {
                this.queryFilters.Add(ATTRIBUTES_KEY, filterToAdd);
            }
        }

        public void removeAttribute(String attributeToRemove) {

            if (attributeToRemove == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.ATTRIBUTE_TO_REMOVE_CANNOT_BE_NULL);
            }
            if (attributeToRemove.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.ATTRIBUTE_TO_REMOVE_CANNOT_BE_EMPTY);
            }

            removeCommaSeperatedValues(ATTRIBUTES_KEY, attributeToRemove);
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
            if (!verifyReviewScore(filterToAdd)) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.REVIEW_SCORE_IS_NOT_IN_CORRECT_FORMAT);
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
            this.nonQueryFilters.Remove(REVIEW_SCORE_KEY);
        }

        /**
         * Provides the string representation of the filters class
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return toString the string representation of the filters class
         **/

        public String toString() {

            String toString = "Query Filters:\n";

            foreach(String key in this.queryFilters.Keys) {
                toString += key + " " + this.queryFilters[key] + "\n";
            }

            toString += "Non Query Filters:\n"; 

            foreach(String key in this.nonQueryFilters.Keys) {
                toString += key + " " + this.nonQueryFilters[key] + "\n";
            }

            return toString;
        }

        private static Boolean verifyRadius(String radiusToVerify) {

            Regex validRadiusRegex = new Regex(@"^([0-9]){1,}$");

            Boolean isValid = validRadiusRegex.IsMatch(radiusToVerify);

            return isValid;
        }

        private static Boolean verifyPrice(String priceToVerify) {

            Regex validPriceRegex = new Regex(@"^((1|2|3|4)(,(1|2|3|4)){0,3})$");

            Boolean isValid = validPriceRegex.IsMatch(priceToVerify);

            return isValid;
        }

        private static Boolean verifyBoolean(String booleanToVerify) {

            Regex validBooleanRegex = new Regex(@"^(true)$");

            Boolean isValid = validBooleanRegex.IsMatch(booleanToVerify);

            return isValid;
        }

        private static Boolean verifyReviewScore(String reviewScoreToVerify) {

            Regex validBooleanRegex = new Regex(@"^(([1-5])|([1-4].[0-9])|([5].0))$");

            Boolean isValid = validBooleanRegex.IsMatch(reviewScoreToVerify);

            return isValid;
        }

        private void removeCommaSeperatedValues(String key, String valueToRemove) {

            if (this.queryFilters.ContainsKey(key)) {
                List<String> split_value = this.queryFilters[key].Split(',').ToList();
                split_value.Remove(valueToRemove);

                if (split_value.Count() == 0) {
                    this.queryFilters.Remove(key);
                }
                else {
                    this.queryFilters[key] = String.Join(",", split_value);
                }
            }
        }
    }
}