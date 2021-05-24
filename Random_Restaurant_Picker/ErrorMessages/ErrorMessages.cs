namespace Random_Restaurant_Picker.ErrorMessages {
    /// <summary>
    /// This class holds the error messages for the application
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    ///
    /// <version>
    /// 22-Dec-2020
    /// </version>

    public class ErrorMessages {
        #region Data members

        //The error messages for the restaurant class

        /// <summary>
        /// The restaurant name cannot be null
        /// </summary>
        public const string RESTAURANT_NAME_CANNOT_BE_NULL = "The restaurant name cannot be null";
        /// <summary>
        /// The restaurant name cannot be empty
        /// </summary>
        public const string RESTAURANT_NAME_CANNOT_BE_EMPTY = "The restaurant name cannot be empty";
        /// <summary>
        /// The restaurant phone number cannot be null
        /// </summary>
        public const string RESTAURANT_PHONE_NUMBER_CANNOT_BE_NULL = "The restaurant phone number cannot be null";
        /// <summary>
        /// The restaurant phone number cannot be empty
        /// </summary>
        public const string RESTAURANT_PHONE_NUMBER_CANNOT_BE_EMPTY = "The restaurant phone number cannot be empty";
        /// <summary>
        /// The restaurant price cannot be null
        /// </summary>
        public const string RESTAURANT_PRICE_CANNOT_BE_NULL = "The restaurant price cannot be null";
        /// <summary>
        /// The restaurant price cannot be empty
        /// </summary>
        public const string RESTAURANT_PRICE_CANNOT_BE_EMPTY = "The restaurant price cannot be empty";
        /// <summary>
        /// The restaurant location cannot be null
        /// </summary>
        public const string RESTAURANT_LOCATION_CANNOT_BE_NULL = "The restaurant location cannot be null";
        /// <summary>
        /// The restaurant location cannot be empty
        /// </summary>
        public const string RESTAURANT_LOCATION_CANNOT_BE_EMPTY = "The restaurant location cannot be empty";
        /// <summary>
        /// The restaurant hours cannot be null
        /// </summary>
        public const string RESTAURANT_HOURS_CANNOT_BE_NULL = "The restaurant hours cannot be null";
        /// <summary>
        /// The restaurant hours cannot be empty
        /// </summary>
        public const string RESTAURANT_HOURS_CANNOT_BE_EMPTY = "The restaurant hours cannot be empty";
        /// <summary>
        /// The restaurant distance cannot be null
        /// </summary>
        public const string RESTAURANT_DISTANCE_CANNOT_BE_NULL = "The restaurant distance cannot be null";

        /// <summary>
        /// The restaurant distance cannot be empty
        /// </summary>
        public const string RESTAURANT_DISTANCE_CANNOT_BE_EMPTY = "The restaurant distance cannot be empty";
        /// <summary>
        /// The restaurant review score cannot be less than zero
        /// </summary>
        public const string RESTAURANT_REVIEW_SCORE_CANNOT_BE_LESS_THAN_ZERO = "The restaurant review score cannot be less than zero";
        /// <summary>
        /// The restaurant review score cannot be more than five
        /// </summary>
        public const string RESTAURANT_REVIEW_SCORE_CANNOT_BE_MORE_THAN_FIVE = "The restaurant review score cannot be more than five";
        /// <summary>
        /// The restaurant review count cannot be less than zero
        /// </summary>
        public const string RESTAURANT_REVIEW_COUNT_CANNOT_BE_LESS_THAN_ZERO = "The restaurant review count cannot be less than zero";
        /// <summary>
        /// The restaurant menu URL cannot be null
        /// </summary>
        public const string RESTAURANT_MENU_URL_CANNOT_BE_NULL = "The restaurant menu url cannot be null";
        /// <summary>
        /// The restaurant menu URL cannot be empty
        /// </summary>
        public const string RESTAURANT_MENU_URL_CANNOT_BE_EMPTY = "The restaurant menu url cannot be empty";
        /// <summary>
        /// The restaurant image URL cannot be null
        /// </summary>
        public const string RESTAURANT_IMAGE_URL_CANNOT_BE_NULL = "The restaurant image url cannot be null";
        /// <summary>
        /// The restaurant image URL cannot be empty
        /// </summary>
        public const string RESTAURANT_IMAGE_URL_CANNOT_BE_EMPTY = "The restaurant image url cannot be empty";
        /// <summary>
        /// The restaurant identifier cannot be null
        /// </summary>
        public const string RESTAURANT_ID_CANNOT_BE_NULL = "The restaurant id cannot be null";
        /// <summary>
        /// The restaurant identifier cannot be empty
        /// </summary>
        public const string RESTAURANT_ID_CANNOT_BE_EMPTY = "The restaurant id cannot be empty";

        //The error messages for the restaurant manager class

        /// <summary>
        /// The restaurant to add cannot be null
        /// </summary>
        public const string RESTAURANT_TO_ADD_CANNOT_BE_NULL = "The restaurant to add cannot be null";
        /// <summary>
        /// The restaurant to remove cannot be null
        /// </summary>
        public const string RESTAURANT_TO_REMOVE_CANNOT_BE_NULL = "The restaurant to remove cannot be null";
        /// <summary>
        /// The minimum restaurant index cannot be less than zero
        /// </summary>
        public const string MINIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO = "The minimum restaurant index cannot be less than zero";
        /// <summary>
        /// The maximum restaurant index cannot be less than zero
        /// </summary>
        public const string MAXIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO = "The maximum restaurant index cannot be less than zero";
        /// <summary>
        /// The minimum restaurant index cannot be more than maximum restaurant index
        /// </summary>
        public const string MINIMUM_RESTAURANT_INDEX_CANNOT_BE_MORE_THAN_MAXIMUM_RESTAURANT_INDEX = "The minimum restaurant index cannot be more than the maximum restaurant index";

        //The error messages for the restaurant filters class

        /// <summary>
        /// The filter to add cannot be null
        /// </summary>
        public const string FILTER_TO_ADD_CANNOT_BE_NULL = "The filter to add cannot be null";
        /// <summary>
        /// The filter to add cannot be empty
        /// </summary>
        public const string FILTER_TO_ADD_CANNOT_BE_EMPTY = "The filter to add cannot be null";
        /// <summary>
        /// The price to remove cannot be null
        /// </summary>
        public const string PRICE_TO_REMOVE_CANNOT_BE_NULL = "The price to remove cannot be null";
        /// <summary>
        /// The price to remove cannot be empty
        /// </summary>
        public const string PRICE_TO_REMOVE_CANNOT_BE_EMPTY = "The price to remove cannot be empty";
        /// <summary>
        /// The radius to add is not in correct format
        /// </summary>
        public const string RADIUS_TO_ADD_IS_NOT_IN_CORRECT_FORMAT = "The radius to add is not in the correct format";
        /// <summary>
        /// The price to add is not in correct format
        /// </summary>
        public const string PRICE_TO_ADD_IS_NOT_IN_CORRECT_FORMAT = "The price to add is not in the correct format";
        /// <summary>
        /// The open now is not in correct format
        /// </summary>
        public const string OPEN_NOW_IS_NOT_IN_CORRECT_FORMAT = "The open now field is not in correct format";
        /// <summary>
        /// The attribute to remove cannot be null
        /// </summary>
        public const string ATTRIBUTE_TO_REMOVE_CANNOT_BE_NULL = "The attribute to remove cannot be null";
        /// <summary>
        /// The attribute to remove cannot be empty
        /// </summary>
        public const string ATTRIBUTE_TO_REMOVE_CANNOT_BE_EMPTY = "The attribute to remove cannot be empty";
        /// <summary>
        /// The handicap accessible is not in correct format
        /// </summary>
        public const string HANDICAP_ACCESSIBLE_IS_NOT_IN_CORRECT_FORMAT = "The handicap accessible field is not in the correct format";
        /// <summary>
        /// The accepts reservations is not in correct format
        /// </summary>
        public const string ACCEPTS_RESERVATIONS_IS_NOT_IN_CORRECT_FORMAT = "The accepts reservations field is not in the correct format";
        /// <summary>
        /// The new restaurants is not in correct format
        /// </summary>
        public const string NEW_RESTAURANTS_IS_NOT_IN_CORRECT_FORMAT = "The new restaurants field is not in the correct format";
        /// <summary>
        /// The review score is not in correct format
        /// </summary>
        public const string REVIEW_SCORE_IS_NOT_IN_CORRECT_FORMAT = "The review score field is not in the correct format";

        //The error messages for the restaurant query class

        /// <summary>
        /// The filters to query cannot be null
        /// </summary>
        public const string FILTERS_TO_QUERY_CANNOT_BE_NULL = "The filters to add to the query cannot be null";
        /// <summary>
        /// The restaurant manager for query cannot be null
        /// </summary>
        public const string RESTAURANT_MANAGER_FOR_QUERY_CANNOT_BE_NULL = "The restaurant manager for the query cannot be null";
        /// <summary>
        /// The cannot populate null restaurant data
        /// </summary>
        public const string CANNOT_POPULATE_NULL_RESTAURANT_DATA = "Cannot get new restaurants, the restaurant data is null";

        #endregion
    }
}