using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 * The class that manages the restaurants retreived from the API
 * 
 * @author Alex DeCesare
 * @version 23-December-2020
 **/

namespace Random_Restaurant_Picker.Models {
    public class RestaurantManager {

        private static readonly int MINIMUM_INDEX = 0;

        private List<Restaurant> theRestaurants;
        private Random random;

        /**
         * The constructor for the restaurant manager
         * 
         * @precondition noneC:\Users\alexd\source\repos\Random_Restaurant_Picker\Random_Restaurant_Picker\Models\RestaurantManager.cs
         * @postcondition none
         **/

        public RestaurantManager() {
            this.theRestaurants = new List<Restaurant>();
            this.random = new Random();
        }

        /**
         * Adds a restaurant to the restaurant manager
         * 
         * @precondition theRestaurantToAdd != null
         * @postcondition none
         * 
         * @param theRestaurantToAdd the restaurant to add to the restaurant manager
         **/

        public void addRestaurant(Restaurant restaurantToAdd) {

            if(restaurantToAdd == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_TO_REMOVE_CANNOT_BE_NULL);
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
         **/

        public void removeRestaurant(Restaurant theRestaurantToRemove) {

            if(theRestaurantToRemove == null) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_TO_REMOVE_CANNOT_BE_NULL);
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
         **/

        public int getNumberOfRestaurants() {

            int size = 0;

            foreach(Restaurant restaurant in this.theRestaurants) {
                size++;
            }

            return size;
        }

        /**
         * Returns a random restaurant
         * 
         * @precondition 
         *      maximumRandomIndex > 0
         *      minimumRandomIndex > 0
         *      maximumRandomIndex > minimumRandomIndex
         * 
         * @postcondition none
         * 
         * @param minimumRandomIndex the minimum index to find a random restaurant
         * @param maximumRandomIndex the maximum index to find a random restaurant
         * 
         * @return theRandomRestaurant the random restaurant
         **/

        public Restaurant pickRandomRestaurant(int minimumRandomIndex, int maximumRandomIndex) {

            if (minimumRandomIndex < MINIMUM_INDEX) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.MINIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO);
            }
            if (maximumRandomIndex < MINIMUM_INDEX) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.MAXIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO);
            }
            if (maximumRandomIndex < minimumRandomIndex) {
                throw new System.ArgumentException(ErrorMessages.ErrorMessages.MINIMUM_RESTAURANT_INDEX_CANNOT_BE_MORE_THAN_MAXIMUM_RESTAURANT_INDEX);
            }
            if (this.getNumberOfRestaurants() == 0) {
                return null;
            }

            int randomIndex = this.random.Next(minimumRandomIndex, maximumRandomIndex);
            Restaurant theRandomRestaurant = this.theRestaurants[randomIndex];

            return theRandomRestaurant;
        }

        /**
         * returns a string representation of the restaurant manager
         * 
         * @precondition none
         * @postcondition none
         * 
         * @return managerString the restring representation of the restaurant manager
         **/

        public String toString() {

            String managerString = "";

            foreach(Restaurant theRestaurant in this.theRestaurants) {
                managerString += theRestaurant.toString() + "\n";
            }

            return managerString;
        }
    }
}