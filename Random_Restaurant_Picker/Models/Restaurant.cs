using System;
using System.Web.WebPages;

namespace Random_Restaurant_Picker.Models {
    /**
     * The class responsible for holding the information for each restaurant
     * 
     * @author Alex DeCesare
     * @version 12-December-2020
     */
    public class Restaurant {
        #region Data members

        private const int RESTAURANT_MINIMUM_REVIEW_COUNT = 0;
        private const int RESTAURANT_MINIMUM_REVIEW_SCORE = 1;
        private const int RESTAURANT_MAXIMUM_REVIEW_SCORE = 5;

        #endregion

        #region Properties

        public string Name { get; }
        public string Price { get; }
        public string Location { get; }
        public string Hours { get; }
        public string Distance { get; }
        public double ReviewScore { get; }
        public int ReviewCount { get; }
        public string MenuUrl { get; }
        public string ImageUrl { get; }
        public string Id { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     The constructor for the restaurant class
        /// </summary>
        /// <precondition>
        ///     name                DOES NOT EQUAL null
        ///     name.isEmpty()      EQUALS False
        ///     price               DOES NOT EQUAL null
        ///     price.isEmpty()     EQUALS False
        ///     location            DOES NOT EQUAL null
        ///     location.isEmpty()  EQUALS False
        ///     hours               DOES NOT EQUAL null
        ///     hours.isEmpty()     EQUALS False
        ///     distance            DOES NOT EQUAL null
        ///     distance.isEmpty()  EQUALS False
        ///     reviewScore         MORE THAN OR EQUAL TO 0
        ///     reviewScore         LESS THAN OR EQUAL TO 5
        ///     reviewCount         MORE THAN OR EQUAL TO 0
        ///     menuURL             DOES NOT EQUAL null
        ///     menuURL.isEmpty()   EQUALS False
        ///     imageURL            DOES NOT EQUAL null
        ///     imageURL.isEmpty()  EQUALS False
        ///     id                  DOES NOT EQUAL null
        ///     id.isEmpty()        EQUALS False
        /// </precondition>
        /// <postcondition>
        ///     this.name           EQUALS name
        ///     this.price          EQUALS price
        ///     this.location       EQUALS location
        ///     this.hours          EQUALS hours
        ///     this.distance       EQUALS distance
        ///     this.reviewScore    EQUALS reviewScore
        ///     this.reviewCount    EQUALS reviewCount
        ///     this.menuUrl        EQUALS menuUrl
        ///     this.imageUrl       EQUALS imageUrl
        ///     this.id             EQUALS id
        /// </postcondition>
        /// <param name="name">the restaurant's name</param>
        /// <param name="price">the restaurant's price</param>
        /// <param name="location">the address of the restaurant</param>
        /// <param name="hours">the hours the restaurant is open</param>
        /// <param name="distance">the distance the restaurant is from the user</param>
        /// <param name="reviewScore">the review score of the restaurant</param>
        /// <param name="reviewCount">the number of reviews for the restaurant</param>
        /// <param name="menuUrl">the URL to the restaurants menu</param>
        /// <param name="imageUrl">the URL to the restaurants image</param>
        /// <param name="id">the yelp id of the restaurant</param>
        public Restaurant(string name, string price, string location, string hours, string distance, double reviewScore,
            int reviewCount, string menuUrl, string imageUrl, string id) {
            checkPreconditions(name, price, location, hours, distance, reviewScore, reviewCount, menuUrl, imageUrl, id);

            this.Name = name;
            this.Price = price;
            this.Location = location;
            this.Hours = hours;
            this.Distance = distance;
            this.ReviewScore = reviewScore;
            this.ReviewCount = reviewCount;
            this.MenuUrl = menuUrl;
            this.ImageUrl = imageUrl;
            this.Id = id;
        }

        #endregion

        #region Methods

        /**
         * Returns the string representation of the restaurant
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the string representation of the restaurant object
         */
        public override string ToString() {
            return "Restaurant (name: " + this.Name + " price: " + this.Price + " location: " + this.Location +
                   " hours: " + this.Hours + " distance: " + this.Distance + " review score: " + this.ReviewScore +
                   " review count: " + this.ReviewCount + " menu URL: " + this.MenuUrl + " image URL: " +
                   this.ImageUrl + " id: " + this.Id + ')';
        }

        private static void checkPreconditions(string name, string price, string location, string hours,
            string distance, double reviewScore, int reviewCount, string menuUrl, string imageUrl, string id) {
            if (name == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_NAME_CANNOT_BE_NULL);
            }

            if (name.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_NAME_CANNOT_BE_EMPTY);
            }

            if (price == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_PRICE_CANNOT_BE_NULL);
            }

            if (price.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_PRICE_CANNOT_BE_EMPTY);
            }

            if (location == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_LOCATION_CANNOT_BE_NULL);
            }

            if (location.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_LOCATION_CANNOT_BE_EMPTY);
            }

            if (hours == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_HOURS_CANNOT_BE_NULL);
            }

            if (hours.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_HOURS_CANNOT_BE_EMPTY);
            }

            if (distance == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_DISTANCE_CANNOT_BE_NULL);
            }

            if (distance.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_DISTANCE_CANNOT_BE_EMPTY);
            }

            if (reviewScore < RESTAURANT_MINIMUM_REVIEW_SCORE) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .RESTAURANT_REVIEW_SCORE_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (reviewScore > RESTAURANT_MAXIMUM_REVIEW_SCORE) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .RESTAURANT_REVIEW_SCORE_CANNOT_BE_MORE_THAN_FIVE);
            }

            if (reviewCount < RESTAURANT_MINIMUM_REVIEW_COUNT) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .RESTAURANT_REVIEW_COUNT_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (menuUrl == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_MENU_URL_CANNOT_BE_NULL);
            }

            if (menuUrl.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_MENU_URL_CANNOT_BE_EMPTY);
            }

            if (imageUrl == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_IMAGE_URL_CANNOT_BE_NULL);
            }

            if (imageUrl.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_IMAGE_URL_CANNOT_BE_EMPTY);
            }

            if (id == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_ID_CANNOT_BE_NULL);
            }

            if (id.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_ID_CANNOT_BE_EMPTY);
            }
        }

        #endregion
    }
}