using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests {
    [TestClass]
    public class TestAddRestaurant {

        [TestMethod]
        public void shouldNotAddNullRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Assert.ThrowsException<ArgumentException>(() => theManager.addRestaurant(null));
        }

        [TestMethod]
        public void shouldAddOneRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            theManager.addRestaurant(theRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)\n", theManager.toString());
        }

        [TestMethod]
        public void shouldAddManyRestaurants() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "$$$", "Senoia GA", "8:00 - 6:00", 0, 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "$$", "Senoia GA", "9:00 - 2:00", 25, 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.addRestaurant(firstRestaurant);
            theManager.addRestaurant(secondRestaurant);
            theManager.addRestaurant(thirdRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)\n"
                + "Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)\n"
                + "Restaurant (name: Senoia Coffee price: $$ location: Senoia GA hours: 9:00 - 2:00 distance: 25 review score: 5 review count: 0 menu URL: MenuURL.com image URL: ImageURL.com id: 7)\n", theManager.toString());
        }
    }
}
