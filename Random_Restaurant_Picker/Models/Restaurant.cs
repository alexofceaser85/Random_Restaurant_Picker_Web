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
        private string _Hours;

        #endregion

        #region Properties

        /// <summary>
        /// The restaurant name (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant name.
        /// </value>
        public string Name { get; }
        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; }
        /// <summary>
        /// The restaurant price (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant price.
        /// </value>
        public string Price { get; }
        /// <summary>
        /// The restaurant's location (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's location.
        /// </value>
        public string Location { get; }
        /// <summary>
        /// The restaurant's hours (has a getter and setter).
        /// </summary>
        /// <value>
        /// The restaurant's hours.
        /// </value>
        public string Hours {
            get { return _Hours;}
            set { this._Hours = value; }
        }
        /// <summary>
        /// The restaurant's distance (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's distance.
        /// </value>
        public string Distance { get; }
        /// <summary>
        /// The restaurant's review score (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's review score.
        /// </value>
        public double ReviewScore { get; }
        /// <summary>
        /// The restaurant's review count (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's review count.
        /// </value>
        public int ReviewCount { get; }
        /// <summary>
        /// The restaurant's menu url (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's menu url.
        /// </value>
        public string MenuUrl { get; }
        /// <summary>
        /// The restaurant's menu url (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's menu url.
        /// </value>
        public string ImageUrl { get; }
        /// <summary>
        /// The restaurant's id (has only a getter).
        /// </summary>
        /// <value>
        /// The restaurant's id.
        /// </value>
        public string Id { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     The constructor for the restaurant class
        /// </summary>
        /// <precondition>
        ///     name                    != null
        ///     name.isEmpty()          == False
        ///     phoneNumber             != null
        ///     phoneNumber.isEmpty()   == False
        ///     price                   != null
        ///     price.isEmpty()         == False
        ///     hours                   != null
        ///     hours.isEmpty()         == False
        ///     distance                != null
        ///     distance.isEmpty()      == False
        ///     reviewScore             MORE THAN OR EQUAL TO 0
        ///     reviewScore             LESS THAN OR EQUAL TO 5
        ///     reviewCount             MORE THAN OR EQUAL TO 0
        ///     menuURL                 != null
        ///     menuURL.isEmpty()       == False
        ///     imageURL                != null
        ///     imageURL.isEmpty()      == False
        ///     id                      != null
        ///     id.isEmpty()            == False
        /// </precondition>
        /// <postcondition>
        ///     this.Name               == name
        ///     this.PhoneNumber        == phoneNumber
        ///     this.Price              == price
        ///     this.Location           == location
        ///     this.Hours              == null
        ///     this.Distance           == distance
        ///     this.ReviewScore        == reviewScore
        ///     this.ReviewCount        == reviewCount
        ///     this.MenuUrl            == menuUrl
        ///     this.ImageUrl           == imageUrl
        ///     this.Id                 == id
        /// </postcondition>
        /// <param name="name">the restaurant's name</param>
        /// <param name="phoneNumber">the restaurant's phone number</param>
        /// <param name="price">the restaurant's price</param>
        /// <param name="location">the address of the restaurant</param>
        /// <param name="hours">the hours the restaurant is open</param>
        /// <param name="distance">the distance the restaurant is from the user</param>
        /// <param name="reviewScore">the review score of the restaurant</param>
        /// <param name="reviewCount">the number of reviews for the restaurant</param>
        /// <param name="menuUrl">the URL to the restaurants menu</param>
        /// <param name="imageUrl">the URL to the restaurants image</param>
        /// <param name="id">the yelp id of the restaurant</param>
        public Restaurant(string name, string phoneNumber, string price, string location, string hours, string distance, double reviewScore, int reviewCount, string menuUrl, string imageUrl, string id) {
            checkPreconditions(name, phoneNumber, price, location, hours, distance, reviewScore, reviewCount, menuUrl, imageUrl, id);

            this.Name = name;
            this.PhoneNumber = phoneNumber;
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

        /// <summary>
        /// Returns the string representation of the restaurant
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
        /// <returns>
        /// A <see cref="System.String" /> that represents the restaurant.
        /// </returns>
        public override string ToString() {
            return "Restaurant (name: " + this.Name + " price: " + this.Price + " location: " + this.Location +
                   " hours: " + this.Hours + " distance: " + this.Distance + " review score: " + this.ReviewScore +
                   " review count: " + this.ReviewCount + " menu URL: " + this.MenuUrl + " image URL: " +
                   this.ImageUrl + " id: " + this.Id + ')';
        }

        private static void checkPreconditions(string name, string phoneNumber, string price, string location, string hours, string distance, double reviewScore, int reviewCount, string menuUrl, string imageUrl, string id) {
            if (name == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_NAME_CANNOT_BE_NULL);
            }

            if (name.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_NAME_CANNOT_BE_EMPTY);
            }

            if (phoneNumber == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_PHONE_NUMBER_CANNOT_BE_NULL);
            }

            if (phoneNumber.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_PHONE_NUMBER_CANNOT_BE_EMPTY);
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

            if (distance == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_DISTANCE_CANNOT_BE_NULL);
            }

            if (distance.IsEmpty()) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_DISTANCE_CANNOT_BE_EMPTY);
            }

            if (reviewScore < RESTAURANT_MINIMUM_REVIEW_SCORE) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_REVIEW_SCORE_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (reviewScore > RESTAURANT_MAXIMUM_REVIEW_SCORE) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_REVIEW_SCORE_CANNOT_BE_MORE_THAN_FIVE);
            }

            if (reviewCount < RESTAURANT_MINIMUM_REVIEW_COUNT) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_REVIEW_COUNT_CANNOT_BE_LESS_THAN_ZERO);
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