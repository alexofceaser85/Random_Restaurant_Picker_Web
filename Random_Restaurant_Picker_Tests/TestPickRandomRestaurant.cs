using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests {
    [TestClass]
    public class TestPickRandomRestaurant {
        [TestMethod]
        public void shouldReturnNullIfManagerIsEmpty() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.AreEqual(null, theManager.pickRandomRestaurant(0, 5));
        }

        [TestMethod]
        public void shouldNotAllowMinimumRandomIndexOneBelowMinimum() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.ThrowsException<ArgumentException>(() => theManager.pickRandomRestaurant(-1, 5));
        }

        [TestMethod]
        public void shouldNotAllowMinimumRandomIndexWellBelowMinimum() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.ThrowsException<ArgumentException>(() => theManager.pickRandomRestaurant(-50, 5));
        }

        [TestMethod]
        public void shouldNotAllowMaximumRandomIndexOneBelowMinimum() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.ThrowsException<ArgumentException>(() => theManager.pickRandomRestaurant(5, -50));
        }

        [TestMethod]
        public void shouldNotAllowMaximumRandomIndexWellBelowMinimum() {
            RestaurantManager theManager = new RestaurantManager();

            Assert.ThrowsException<ArgumentException>(() => theManager.pickRandomRestaurant(5, -50));
        }

        [TestMethod]
        public void shouldAllowMinimumAndMaximumIndexAtMinimum() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            theManager.addRestaurant(theRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 Miles review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)", theManager.pickRandomRestaurant(0, 0).toString());
        }

        [TestMethod]
        public void shouldAllowMinimumAndMaximumIndexOneAboveMinimum() {

            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.addRestaurant(firstRestaurant);
            theManager.addRestaurant(secondRestaurant);
            theManager.addRestaurant(thirdRestaurant);

            Assert.AreEqual("Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)", theManager.pickRandomRestaurant(1, 1).toString());
        }

        [TestMethod]
        public void shouldAllowMinimumAndMaximumIndexWellAboveMinimum() {

            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Beez Freeze", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant fourthRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant fifthRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Mcdonalds", "$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant sixthRestaurant = new Random_Restaurant_Picker.Models.Restaurant("The Dynasty", "$", "Newnan GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.addRestaurant(firstRestaurant);
            theManager.addRestaurant(secondRestaurant);
            theManager.addRestaurant(thirdRestaurant);
            theManager.addRestaurant(fourthRestaurant);
            theManager.addRestaurant(fifthRestaurant);
            theManager.addRestaurant(sixthRestaurant);

            Assert.AreEqual("Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)", theManager.pickRandomRestaurant(3, 3).toString());
        }
    }
}
