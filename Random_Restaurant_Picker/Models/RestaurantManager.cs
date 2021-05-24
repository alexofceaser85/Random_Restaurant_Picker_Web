using System;
using System.Collections.Generic;

namespace Random_Restaurant_Picker.Models {

    /// <summary>
    /// The class that manages the restaurants retrieved from the API
    /// </summary>
    ///
    /// <author>
    /// Alex DeCesare
    /// </author>
    /// <version>
    /// 23-December-2020
    /// </version>
    public class RestaurantManager {
        #region Data members

        private const int MINIMUM_INDEX = 0;

        private readonly List<Restaurant> theRestaurants;
        private Restaurant theRandomRestaurant;
        private readonly Random random;

        #endregion

        #region Constructors

        /// <summary>
        /// The constructor of the <see cref="RestaurantManager"/> class.
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>
        public RestaurantManager() {
            this.theRestaurants = new List<Restaurant>();
            this.random = new Random();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the random restaurant.
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>
        /// <returns>The random restaurant</returns>
        public Restaurant GetRandomRestaurant() {
            return this.theRandomRestaurant;
        }

        /// <summary>
        /// Adds a restaurant to the restaurant manager
        /// </summary>
        ///
        /// <precondition>
        /// theRestaurantToAdd != null
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theRandomRestaurant.Size() == this.theRandomRestaurant.Size() + 1
        /// </postcondition>
        /// 
        /// <param name="restaurantToAdd">The restaurant to add.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddRestaurant(Restaurant restaurantToAdd) {
            if (restaurantToAdd == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_TO_ADD_CANNOT_BE_NULL);
            }

            this.theRestaurants.Add(restaurantToAdd);
        }

        /// <summary>
        /// Removes a restaurant from the restaurant manager
        /// </summary>
        ///
        /// <precondition>
        /// theRestaurantToAdd != null
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theRandomRestaurant.Size() == this.theRandomRestaurant.Size() - 1
        /// </postcondition>
        /// 
        /// <param name="theRestaurantToRemove">The restaurant to remove.</param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveRestaurant(Restaurant theRestaurantToRemove) {
            if (theRestaurantToRemove == null) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.RESTAURANT_TO_REMOVE_CANNOT_BE_NULL);
            }

            this.theRestaurants.Remove(theRestaurantToRemove);
        }

        /// <summary>
        /// Gets the number of restaurants in the manager.
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// none
        /// </postcondition>
        /// <returns>The number of restaurants in the manager</returns>
        public int GetNumberOfRestaurants() {
            return this.theRestaurants.Count;
        }

        /// <summary>
        /// Picks and returns the random restaurant.
        /// </summary>
        ///
        /// <precondition>
        /// minimumRandomIndex MORE THAN OR EQUAL TO MINIMUM_INDEX
        /// maximumRandomIndex MORE THAN OR EQUAL TO MINIMUM_INDEX
        /// maximumRandomIndex MORE THAN OR EQUAL TO minimumRandomIndex
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theRandomRestaurant == theRandomRestaurant
        /// </postcondition>
        /// 
        /// <param name="minimumRandomIndex">Minimum value of the random index.</param>
        /// <param name="maximumRandomIndex">Maximum value of the random index.</param>
        ///
        /// <returns>
        /// Returns The randomly picked restaurant if this.GetNumberOfRestaurants != 0 (there are restaurants in the manager)
        /// Returns zero if this.GetNumberOfRestaurants == 0 (there are no restaurants in the manager)
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public Restaurant PickRandomRestaurant(int minimumRandomIndex, int maximumRandomIndex) {
            if (minimumRandomIndex < MINIMUM_INDEX) {
                throw new ArgumentException(ErrorMessages.ErrorMessages
                                                         .MINIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (maximumRandomIndex < MINIMUM_INDEX) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.MAXIMUM_RESTAURANT_INDEX_CANNOT_BE_LESS_THAN_ZERO);
            }

            if (maximumRandomIndex < minimumRandomIndex) {
                throw new ArgumentException(ErrorMessages.ErrorMessages.MINIMUM_RESTAURANT_INDEX_CANNOT_BE_MORE_THAN_MAXIMUM_RESTAURANT_INDEX);
            }

            if (this.GetNumberOfRestaurants() == 0) {
                return null;
            }

            var randomIndex = this.random.Next(minimumRandomIndex, maximumRandomIndex);
            var theRandomRestaurant = this.theRestaurants[randomIndex];
            this.theRandomRestaurant = theRandomRestaurant;
            return this.theRandomRestaurant;
        }

        /// <summary>
        /// returns a string representation of the restaurant manager
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
        /// <returns>managerString the string representation of the restaurant manager</returns>
        public override string ToString() {
            var managerString = "";

            foreach (var theRestaurant in this.theRestaurants) {
                managerString += theRestaurant + "\n";
            }

            return managerString;
        }

        #endregion
    }
}