using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantManager {
    [TestClass]
    public class TestGetRandomRestaurant {
        [TestMethod]
        public void ShouldReturnNullIfNoRandomRestaurantSet() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.AreEqual(null, theManager.GetRandomRestaurant());
        }

        [TestMethod]
        public void shouldGetRandomRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");

            theManager.AddRestaurant(theRestaurant);

            theManager.PickRandomRestaurant(0, theManager.GetNumberOfRestaurants());

            Assert.AreEqual("Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)", theManager.GetRandomRestaurant().ToString());
        }
    }
}
