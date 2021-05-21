

/**
 * This class holds the error messages for the application
 * 
 * @author Alex DeCesare
 * @version 22-Dec-2020
 **/

namespace Random_Restaurant_Picker.ErrorMessages {
    public class ErrorMessages {
        #region Data members

        //The error messages for the restaurant class

        public static readonly string RESTAURANT_NAME_CANNOT_BE_NULL = "The restaurant name cannot be null";
        public static readonly string RESTAURANT_NAME_CANNOT_BE_EMPTY = "The restaurant name cannot be empty";
        public static readonly string RESTAURANT_PRICE_CANNOT_BE_NULL = "The restaurant price cannot be null";
        public static readonly string RESTAURANT_PRICE_CANNOT_BE_EMPTY = "The restaurant price cannot be empty";
        public static readonly string RESTAURANT_LOCATION_CANNOT_BE_NULL = "The restaurant location cannot be null";
        public static readonly string RESTAURANT_LOCATION_CANNOT_BE_EMPTY = "The restaurant loccation cannot be empty";
        public static readonly string RESTAURANT_HOURS_CANNOT_BE_NULL = "The restaurant hours cannot be null";
        public static readonly string RESTAURANT_HOURS_CANNOT_BE_EMPTY = "The restaurant hours cannot be empty";
        public static readonly string RESTAURANT_DISTANCE_CANNOT_BE_NULL = "The restaurant distance cannot be null";
        public static readonly string RESTAURANT_DISTANCE_CANNOT_BE_EMPTY = "The restaurant distance cannot be empty";

        public static readonly string RESTAURANT_REVIEW_SCORE_CANNOT_BE_LESS_THAN_ZERO =
            "The restaurant review score cannot be less than zero";

        public static readonly string RESTAURANT_REVIEW_SCORE_CANNOT_BE_MORE_THAN_FIVE =
            "The restaurant review score cannot be more than five";

        public static readonly string RESTAURANT_REVIEW_COUNT_CANNOT_BE_LESS_THAN_ZERO =
            "The restaurant review count cannot be less than zero";

        public static readonly string RESTAURANT_MENU_URL_CANNOT_BE_NULL = "The restaurant menu url cannot be null";
        public static readonly string RESTAURANT_MENU_URL_CANNOT_BE_EMPTY = "The restaurant menu url cannot be empty";
        public static readonly string RESTAURANT_IMAGE_URL_CANNOT_BE_NULL = "The restaurant image url cannot be null";
        public static readonly string RESTAURANT_IMAGE_URL_CANNOT_BE_EMPTY = "The restaurant image url cannot be empty";
        public static readonly string RESTAURANT_ID_CANNOT_BE_NULL = "The restaurant id cannot be null";
        public static readonly string RESTAURANT_ID_CANNOT_BE_EMPTY = "The restaurant id cannot be empty";

        //The error messages for the restaurant manager class

        public static readonly string RESTAURANT_TO_ADD_CANNOT_BE_NULL = "The restaurant to add cannot be null";
        public static readonly string RESTAURANT_TO_REMOVE_CANNOT_BE_NULL = "The restaurant to remove cannot be null";

        public static readonly string MINIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO =
            "The minimum restaurant index cannot be less than zero";

        public static readonly string MAXIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO =
            "The maximum restaurant index cannot be less than zero";

        public static readonly string MINIMUM_RESTAURANT_INDEX_CANNOT_BE_MORE_THAN_MAXIMUM_RESTAURANT_INDEX =
            "The minimum restaurant index cannot be more than the maximum restaurant index";

        //The error messages for the restaurant filters class

        public static readonly string FILTER_TO_ADD_CANNOT_BE_NULL = "The filter to add cannot be null";
        public static readonly string FILTER_TO_ADD_CANNOT_BE_EMPTY = "The filter to add cannot be null";
        public static readonly string PRICE_TO_REMOVE_CANNOT_BE_NULL = "The price to remove cannot be null";
        public static readonly string PRICE_TO_REMOVE_CANNOT_BE_EMPTY = "The price to remove cannot be empty";

        public static readonly string RADIUS_TO_ADD_IS_NOT_IN_CORRECT_FORMAT =
            "The radius to add is not in the correct format";

        public static readonly string PRICE_TO_ADD_IS_NOT_IN_CORRECT_FORMAT =
            "The price to add is not in the correct format";

        public static readonly string OPEN_NOW_IS_NOT_IN_CORRECT_FORMAT = "The open now field is not in correct format";
        public static readonly string ATTRIBUTE_TO_REMOVE_CANNOT_BE_NULL = "The attribute to remove cannot be null";
        public static readonly string ATTRIBUTE_TO_REMOVE_CANNOT_BE_EMPTY = "The attribute to remove cannot be empty";

        public static readonly string HANDICAP_ACCESSIBLE_IS_NOT_IN_CORRECT_FORMAT =
            "The handicap accessible field is not in the correct format";

        public static readonly string ACCEPTS_RESERVATIONS_IS_NOT_IN_CORRECT_FORMAT =
            "The accepts reservations field is not in the correct format";

        public static readonly string NEW_RESTAURANTS_IS_NOT_IN_CORRECT_FORMAT =
            "The new restaurants field is not in the correct format";

        public static readonly string REVIEW_SCORE_IS_NOT_IN_CORRECT_FORMAT =
            "The review score field is not in the correct format";

        //The error messages for the restaurant query class

        public static readonly string FILTERS_TO_QUERY_CANNOT_BE_NULL =
            "The filters to add to the query cannot be null";

        public static readonly string RESTAURANT_MANAGER_FOR_QUERY_CANNOT_BE_NULL =
            "The restaurant manager for the query cannot be null";

        #endregion
    }
}