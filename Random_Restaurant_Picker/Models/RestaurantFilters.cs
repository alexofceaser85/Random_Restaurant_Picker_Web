using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.WebPages;

namespace Random_Restaurant_Picker.Models {
    /// <summary>
    ///     The class manages the filters for finding a restaurant
    /// </summary>
    /// <author>
    ///     Alex DeCesare
    /// </author>
    /// ///
    /// <version>
    ///     24-Dec-2020
    /// </version>
    public class RestaurantFilters {
        #region Data members

        private const string TERM_KEY = "term";
        private const string LOCATION_KEY = "location";
        private const string RADIUS_KEY = "radius";
        private const string FOOD_CATEGORIES_KEY = "categories";
        private const string PRICE_KEY = "price";
        private const string OPEN_NOW_KEY = "open_now";
        private const string ATTRIBUTES_KEY = "attributes";
        private const string REVIEW_SCORE_KEY = "review_score";
        private readonly Dictionary<string, string> queryFilters;
        private readonly Dictionary<string, string> nonQueryFilters;

        #endregion

        #region Constructors

        /// <summary>
        ///     The constructor for the filters.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>
        ///     this.queryFilters EQUALS new Dictionary&lt;string, string>&gt;()
        ///     this.nonQueryFilters EQUALS new Dictionary&lt;string, string>&gt;()
        /// </postcondition>
        public RestaurantFilters() {
            this.queryFilters = new Dictionary<string, string>();
            this.nonQueryFilters = new Dictionary<string, string>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the query filters dictionary
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>the query filters dictionary</returns>
        public Dictionary<string, string> GetQueryFilters() {
            return this.queryFilters;
        }

        /// <summary>
        ///     Gets the non query filters dictionary
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>the non query filters dictionary</returns>
        public Dictionary<string, string> GetNonQueryFilters() {
            return this.queryFilters;
        }

        /// <summary>
        ///     Adds the term as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The term filter to add</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddTerm(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(TERM_KEY, filterToAdd);
        }

        /// <summary>
        ///     Removes the term as a filter
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveTerm() {
            this.queryFilters.Remove(TERM_KEY);
        }

        /// <summary>
        ///     Adds the location as a filter. Because it is a parameter of the api query it is added to the queryFilters
        ///     dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">the location filter to add</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddLocation(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(LOCATION_KEY, filterToAdd);
        }

        /// <summary>
        ///     Removes the location as a filter
        /// </summary>
        /// <precondition>
        ///     none
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveLocation() {
            this.queryFilters.Remove(LOCATION_KEY);
        }

        /// <summary>
        ///     Adds the radius as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The radius filter to add.</param>
        /// <exception cref="ArgumentException">
        /// </exception>

        public void AddRadius(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if (!verifyRadius(filterToAdd)) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RADIUS_TO_ADD_IS_NOT_IN_CORRECT_FORMAT);
            }

            this.queryFilters.Add(RADIUS_KEY, filterToAdd);
        }

        /// <summary>
        ///     Removes the radius as a filter
        /// </summary>
        /// <precondition>
        ///     none
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveRadius() {
            this.queryFilters.Remove(RADIUS_KEY);
        }

        /// <summary>
        ///     Adds the food category as a filter. Because it is a parameter of the api query it is added to the queryFilters
        ///     dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The filter to add.</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddFoodCategory(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            this.queryFilters.Add(FOOD_CATEGORIES_KEY, filterToAdd);
        }

        /// <summary>
        ///     Removes the food category as a filter
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveFoodCategory() {
            this.queryFilters.Remove(FOOD_CATEGORIES_KEY);
        }

        /// <summary>
        ///     Adds the price as a filter. Because it is a parameter of the api query it is added to the queryFilters dictionary
        ///     The price could either be one value etc. 1, which is equal to $, or multiple values etc. 1,2,3 which is $,$$,$$$
        ///     Because of that the method checks if it needs to add onto the existing price values or make a new price key
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The price filter to add.</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddPrice(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if (!verifyPrice(filterToAdd)) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.PRICE_TO_ADD_IS_NOT_IN_CORRECT_FORMAT);
            }

            if (!this.queryFilters.ContainsKey(PRICE_KEY)) {
                this.queryFilters.Add(PRICE_KEY, filterToAdd);
                return;
            }

            var splitPriceFilters = this.queryFilters[PRICE_KEY].Split(',').ToList();

            if (splitPriceFilters.Contains(filterToAdd)) {
                return;
            }

            splitPriceFilters.Add(filterToAdd);
            var sortedPriceFilters = splitPriceFilters.OrderBy(q => q).ToList();

            this.queryFilters[PRICE_KEY] = string.Join(",", sortedPriceFilters);
        }

        /// <summary>
        ///     Removes the price as a filter. Because the price could either be one value or multiple comma delimited values
        ///     The method checks if it needs to remove the price as a part of the dictionary or just one value.
        /// </summary>
        /// <precondition>
        ///     priceToRemove           DOES NOT EQUAL null
        ///     priceToRemove.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemovePrice(string priceToRemove) {
            if (priceToRemove == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.PRICE_TO_REMOVE_CANNOT_BE_NULL);
            }

            if (priceToRemove.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.PRICE_TO_REMOVE_CANNOT_BE_EMPTY);
            }

            this.removeCommaSeparatedValues(PRICE_KEY, priceToRemove);
        }

        /// <summary>
        ///     Adds the open now boolean as a filter. Because it is a parameter of the api query it is added to the queryFilters
        ///     dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The open now filter to add.</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddOpenNow(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if (!verifyBoolean(filterToAdd)) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.OPEN_NOW_IS_NOT_IN_CORRECT_FORMAT);
            }

            this.queryFilters.Add(OPEN_NOW_KEY, filterToAdd);
        }

        /// <summary>
        ///     Removes open now as a filter
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveOpenNow() {
            this.queryFilters.Remove(OPEN_NOW_KEY);
        }

        /// <summary>
        ///     Adds the attributes as a filter. Because it is a parameter of the api query it is added to the queryFilters
        ///     dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The attribute filter to add.</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddAttribute(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if (this.queryFilters.ContainsKey(ATTRIBUTES_KEY)) {
                var splitAttributes = this.queryFilters[ATTRIBUTES_KEY].Split(',');

                if (!splitAttributes.Contains(filterToAdd)) {
                    this.queryFilters[ATTRIBUTES_KEY] += "," + filterToAdd;
                }
            }
            else {
                this.queryFilters.Add(ATTRIBUTES_KEY, filterToAdd);
            }
        }

        /// <summary>
        ///     Removes the attribute as a filter
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveAttribute(string attributeToRemove) {
            if (attributeToRemove == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.ATTRIBUTE_TO_REMOVE_CANNOT_BE_NULL);
            }

            if (attributeToRemove.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.ATTRIBUTE_TO_REMOVE_CANNOT_BE_EMPTY);
            }

            this.removeCommaSeparatedValues(ATTRIBUTES_KEY, attributeToRemove);
        }

        /// <summary>
        ///     Adds the review score as a filter. Because it is unable to be a parameter of the api query it is added to the
        ///     nonQueryFilters dictionary
        /// </summary>
        /// <precondition>
        ///     filterToAdd           DOES NOT EQUAL null
        ///     filterToAdd.isEmpty() EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count + 1
        /// </postcondition>
        /// <param name="filterToAdd">The review score filter to add.</param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void AddReviewScore(string filterToAdd) {
            if (filterToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_NULL);
            }

            if (filterToAdd.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.FILTER_TO_ADD_CANNOT_BE_EMPTY);
            }

            if (!verifyReviewScore(filterToAdd)) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.REVIEW_SCORE_IS_NOT_IN_CORRECT_FORMAT);
            }

            this.nonQueryFilters.Add(REVIEW_SCORE_KEY, filterToAdd);
        }

        /// <summary>
        ///     Removes the review score as a filter
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>
        ///     this.queryFilters.Count EQUALS this.queryFilters.Count - 1
        /// </postcondition>
        public void RemoveReviewScore() {
            this.nonQueryFilters.Remove(REVIEW_SCORE_KEY);
        }

        /// <summary>
        ///     Provides the string representation of the filters class
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>ToString the string representation of the restaurants filters</returns>
        public override string ToString() {
            var toString = "Query Filters:\n";

            foreach (var key in this.queryFilters.Keys) {
                toString += key + " " + this.queryFilters[key] + "\n";
            }

            toString += "Non Query Filters:\n";

            foreach (var key in this.nonQueryFilters.Keys) {
                toString += key + " " + this.nonQueryFilters[key] + "\n";
            }

            return toString;
        }

        private static bool verifyRadius(string radiusToVerify) {
            var validRadiusRegex = new Regex(@"^([0-9]){1,}$");

            var isValid = validRadiusRegex.IsMatch(radiusToVerify);

            return isValid;
        }

        private static bool verifyPrice(string priceToVerify) {
            var validPriceRegex = new Regex(@"^((1|2|3|4)(,(1|2|3|4)){0,3})$");

            var isValid = validPriceRegex.IsMatch(priceToVerify);

            return isValid;
        }

        private static bool verifyBoolean(string booleanToVerify) {
            var validBooleanRegex = new Regex(@"^(true)$");

            var isValid = validBooleanRegex.IsMatch(booleanToVerify);

            return isValid;
        }

        private static bool verifyReviewScore(string reviewScoreToVerify) {
            var validBooleanRegex = new Regex(@"^(([1-5])|([1-4].[0-9])|([5].0))$");

            var isValid = validBooleanRegex.IsMatch(reviewScoreToVerify);

            return isValid;
        }

        private void removeCommaSeparatedValues(string key, string valueToRemove) {
            if (!this.queryFilters.ContainsKey(key)) {
                return;
            }

            var splitValue = this.queryFilters[key].Split(',').ToList();
            splitValue.Remove(valueToRemove);

            if (!splitValue.Any()) {
                this.queryFilters.Remove(key);
            } else {
                this.queryFilters[key] = string.Join(",", splitValue);
            }
        }

        #endregion
    }
}