using System;
using System.Collections.Generic;

/**
 * The class that manages the restaurants retreived from the API
 * 
 * @author Alex DeCesare
 * @version 23-December-2020
 **/

namespace Random_Restaurant_Picker.Models {
    public class RestaurantManager {
        #region Data members

        private static readonly int MINIMUM_INDEX = 0;

        private readonly List<Restaurant> theRestaurants;
        private Restaurant theRandomRestaurant;
        private readonly Random random;

        #endregion

        #region Constructors

        /**
         * The constructor for the restaurant manager
         * 
         * @precondition noneC:\Users\alexd\source\repos\Random_Restaurant_Picker\Random_Restaurant_Picker\Models\RestaurantManager.cs
         * @postcondition none
         */
        public RestaurantManager() {
            this.theRestaurants = new List<Restaurant>();
            this.random = new Random();
        }

        #endregion

        #region Methods

        /**
         * Gets the random restaurant
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return the random restaurant or null if the random restaurant is not assigned
         */
        public Restaurant getRandomRestaurant() {
            return this.theRandomRestaurant;
        }

        /**
         * Adds a restaurant to the restaurant manager
         * 
         * @precondition theRestaurantToAdd != null
         * @postcondition none
         * 
         * @param theRestaurantToAdd the restaurant to add to the restaurant manager
         */
        public void addRestaurant(Restaurant restaurantToAdd) {
            if (restaurantToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_TO_REMOVE_CANNOT_BE_NULL);
            }

            this.theRestaurants.Add(restaurantToAdd);
        }

        /**
         * Removes a restaurant from the restaurant manager
         * 
         * @precondition theRestaurantToRemove != null
         * @postcondition none
         * 
         * @param theRestaurantToRemove the restaurant to remove from the restaurant manager
         */
        public void removeRestaurant(Restaurant theRestaurantToRemove) {
            if (theRestaurantToRemove == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_TO_REMOVE_CANNOT_BE_NULL);
            }

            this.theRestaurants.Remove(theRestaurantToRemove);
        }

        /**
         * Get the size of the restaurants
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return size the size of the restaurants
         */
        public int getNumberOfRestaurants() {
            var size = 0;

            foreach (var restaurant in this.theRestaurants) {
                size++;
            }

            return size;
        }

        /**
         * Returns a random restaurant
         * 
         * @precondition 
         * maximumRandomIndex > 0
         * minimumRandomIndex > 0
         * maximumRandomIndex > minimumRandomIndex
         * 
         * @postcondition none
         * 
         * @param minimumRandomIndex the minimum index to find a random restaurant
         * @param maximumRandomIndex the maximum index to find a random restaurant
         * 
         * @return theRandomRestaurant the random restaurant
         */
        public Restaurant pickRandomRestaurant(int minimumRandomIndex, int maximumRandomIndex) {
            if (minimumRandomIndex < MINIMUM_INDEX) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .MINIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (maximumRandomIndex < MINIMUM_INDEX) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .MAXIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (maximumRandomIndex < minimumRandomIndex) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .MINIMUM_RESTAURANT_INDEX_CANNOT_BE_MORE_THAN_MAXIMUM_RESTAURANT_INDEX);
            }

            if (this.getNumberOfRestaurants() == 0) {
                return null;
            }

            var randomIndex = this.random.Next(minimumRandomIndex, maximumRandomIndex);
            var theRandomRestaurant = this.theRestaurants[randomIndex];
            this.theRandomRestaurant = theRandomRestaurant;
            return theRandomRestaurant;
        }

        /**
         * returns a string representation of the restaurant manager
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return managerString the restring representation of the restaurant manager
         */
        public string toString() {
            var managerString = "";

            foreach (var theRestaurant in this.theRestaurants) {
                managerString += theRestaurant + "\n";
            }

            return managerString;
        }

        #endregion
    }
}