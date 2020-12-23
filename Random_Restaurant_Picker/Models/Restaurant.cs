using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Random_Restaurant_Picker.ErrorMessages;

namespace Random_Restaurant_Picker.Models {
    /**
     * The class responsible for holding the information for each restaurant
     * 
     * @author Alex DeCesare
     * @version 12-December-2020
     **/

    public class Restaurant {

        private static readonly int RESTAURANT_MINIMUM_DISTANCE = 0;
        private static readonly int RESTAURANT_MINIMUM_REVIEW_SCORE = 1;
        private static readonly int RESTAURANT_MAXIMUM_REVIEW_SCORE = 5;

        private String name;
        private String price;
        private String location;
        private String hours;
        private int distance;
        private double reviewScore;
        private int reviewCount;
        private String menuURL;
        private String imageURL;
        private String id;

        /**
         * The constructor for the restaurant class
         * 
         * @precondition
         *      name                != null
         *      name.isEmpty()      == False
         *      price               != null
         *      price.isEmpty()     == False
         *      location            != null
         *      location.isEmpty()  == False
         *      hours               != null
         *      hours.isEmpty()     == False
         *      distance            >= 0
         *      reviewScore         >= 0 
         *      reviewScore         <= 5
         *      reviewCount         >= 0
         *      menuURL             != null
         *      menuURL.isEmpty()   == False
         *      imageURL            != null
         *      imageURL.isEmpty()  == False
         *      id                  != null
         *      id.isEmpty()        == False
         *      
         *  @postcondition
         *      this.name           == name
         *      this.price          == price
         *      this.location       == location
         *      this.hours          == hours
         *      this.distance       == distance
         *      this.reviewScore    == reviewScore
         *      this.reviewCount    == reviewCount
         *      this.menuURL        == menuURL
         *      this.imageURL       == imageURL
         *      this.id             == id
         *      
         *  @params
         *      name:           the restaurant's name
         *      price:          the restaurant's price
         *      location:       the address of the restauarant
         *      hours:          the hours the restaurant is open
         *      distance:       the distance the restaurant is from the user
         *      reviewScore:    the review score of the restaurant
         *      reviewCount:    the number of reviews for the restaurant
         *      menuURL:        the URL to the restaurants menu
         *      imageURL:       the URL to the restaurants image
         *      id:             the yelp id of the restaurant
         **/

        public Restaurant(String name, String price, String location, String hours, int distance, double reviewScore, int reviewCount, String menuURL, String imageURL, String id) {

            checkPreconditions(name, price, location, hours, distance, reviewScore, menuURL, id);

            this.name = name;
            this.price = price;
            this.location = location;
            this.hours = hours;
            this.distance = distance;
            this.reviewScore = reviewScore;
            this.reviewCount = reviewCount;
            this.menuURL = menuURL;
            this.imageURL = imageURL;
            this.id = id;
        }

        /**
         * the getter for the restaurant name
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant name
         **/

        public String getName() {
            return this.name;
        }

        /**
         * the getter for the restaurant price
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant price
         **/

        public String getPrice() {
            return this.price;
        }

        /**
         * the getter for the restaurant location
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant location
         **/
         public String getLocation() {
            return this.location;
        }

        /**
         * the getter for the restaurant hours
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant hours
         **/
        public String getHours() {
            return this.hours;
        }

        /**
         * the getter for the restaurant distance
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant distance
         **/

        public int getDistance() {
            return this.distance;
        }

        /**
         * the getter for the restaurant review score
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant review score
         **/
         public double getReviewScore() {
            return this.reviewScore;
        }

        /**
         * the getter for the restaurant review count
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant review count
         **/
         public int getReviewCount() {
            return this.reviewCount;
        }

        /**
         * the getter for the restaurant menu URL
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant menu URL
         **/

        public String getMenuURL() {
            return this.menuURL;
        }

        /**
        * the getter for the restaurant image URL
        * 
        * @precondition none
        * @postcondition none
        * 
        * @return the restaurant image URL
        **/

        public String getImageURL() {
            return this.imageURL;
        }

        /**
         * the getter for the restaurant id
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the restaurant id
         **/

        public String getId() {
            return this.id;
        }

        private static void checkPreconditions(string name, string price, string location, string hours, int distance, double reviewScore, string menuURL, string id) {
            if (name == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_NAME_CANNOT_BE_NULL);
            }
            if (name.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_NAME_CANNOT_BE_EMPTY);
            }
            if (price == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_PRICE_CANNOT_BE_NULL);
            }
            if (price.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_PRICE_CANNOT_BE_EMPTY);
            }
            if (location == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_LOCATION_CANNOT_BE_NULL);
            }
            if (location.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_LOCATION_CANNOT_BE_EMPTY);
            }
            if (hours == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_HOURS_CANNOT_BE_NULL);
            }
            if (hours.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_HOURS_CANNOT_BE_EMPTY);
            }
            if (distance < RESTAURANT_MINIMUM_DISTANCE) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_DISTANCE_CANNOT_BE_LESS_THAN_ZERO);
            }
            if (reviewScore < RESTAURANT_MINIMUM_REVIEW_SCORE) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_REVIEW_SCORE_CANNOT_BE_LESS_THAN_ZERO);
            }
            if (reviewScore > RESTAURANT_MAXIMUM_REVIEW_SCORE) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_REVIEW_SCORE_CANNOT_BE_MORE_THAN_FIVE);
            }
            if (menuURL == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_MENU_URL_CANNOT_BE_NULL);
            }
            if (menuURL.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_MENU_URL_CANNOT_BE_EMPTY);
            }
            if (id == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_ID_CANNOT_BE_NULL);
            }
            if (id.IsEmpty()) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_ID_CANNOT_BE_EMPTY);
            }
        }
    }
}