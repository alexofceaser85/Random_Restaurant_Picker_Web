using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantManager {
    [TestClass]
    public class TestGetNumberOfRestaurants {
        [TestMethod]
        public void shouldGetNumberOfRestaurantsForEmptyManager() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.AreEqual(0, theManager.GetNumberOfRestaurants());
        }

        [TestMethod]
        public void shouldGetNumberOfRestaurantsForManagerWithOneRestaurant() {
            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            theManager.AddRestaurant(firstRestaurant);

            Assert.AreEqual(1, theManager.GetNumberOfRestaurants());
        }

        [TestMethod]
        public void shouldGetNumberOfRestaurantsForManagerWithManyRestaurants() {
            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "5 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "770-644-4488", "$$", "Senoia GA", "9:00 - 2:00", "5 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.AddRestaurant(firstRestaurant);
            theManager.AddRestaurant(secondRestaurant);
            theManager.AddRestaurant(thirdRestaurant);

            Assert.AreEqual(3, theManager.GetNumberOfRestaurants());
        }
    }
}
