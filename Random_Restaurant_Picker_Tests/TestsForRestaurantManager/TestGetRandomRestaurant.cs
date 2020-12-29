using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantManager {
    [TestClass]
    public class TestGetRandomRestaurant {
        [TestMethod]
        public void ShouldReturnNullIfNoRandomRestaurantSet() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.AreEqual(null, theManager.getRandomRestaurant());
        }

        [TestMethod]
        public void shouldGetRandomRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");

            theManager.addRestaurant(theRestaurant);

            theManager.pickRandomRestaurant(0, theManager.getNumberOfRestaurants());

            Assert.AreEqual("Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)", theManager.getRandomRestaurant().ToString());
        }
    }
}
