using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests {
    [TestClass]
    public class TestRestaurantConstructor {

        [TestMethod]
        public void constructorShouldNotAllowNullName() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant(null, "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyName() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidName() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual("Matt's Pizza", theRestaurant.getName());
        }

        [TestMethod]
        public void constructorShouldNotAllowNullPrice() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", null, "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyPrice() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidPrice() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual("$$", theRestaurant.getPrice());
        }

        [TestMethod]
        public void constructorShouldNotAllowNullLocation() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", null, "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyLocation() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidLocation() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual("Senoia GA", theRestaurant.getLocation());
        }

        [TestMethod]
        public void constructorShouldNotAllowNullHours() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", null, 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyHours() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "", 5, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidHours() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual("9:00 - 5:00", theRestaurant.getHours());
        }

        [TestMethod]
        public void constructorShouldNotAllowDistanceWellBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", -50, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowDistanceOneBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", -1, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowDistanceAtMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 0, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(0, theRestaurant.getDistance());
        }

        [TestMethod]
        public void constructorShouldAllowDistanceOneAboveMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 1, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(1, theRestaurant.getDistance());
        }

        [TestMethod]
        public void constructorShouldAllowDistanceWellAboveMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 50, 4.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(50, theRestaurant.getDistance());
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreWellBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, -50, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 0, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneTenthBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, .9, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreAtMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 1, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(1, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneTenthAboveMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 1.1, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(1.1, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneAboveMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 2, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(2, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreBetweenMinimumAndMaximum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 3.5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(3.5, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneBelowMaximum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 4, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(4, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneTenthBelowMaximum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 4.9, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(4.9, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreAtMaximum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 5, 5, "URL.com", "URL.com", "5");

            Assert.AreEqual(5, theRestaurant.getReviewScore());
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneTenthAboveMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 5.1, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneAboveMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 6, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreWellAboveMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 50, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewCountWellBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 4, -50, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewCountOneBelowMinimum() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 4, -1, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowReviewCountAtMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 5, 0, "URL.com", "URL.com", "5");

            Assert.AreEqual(0, theRestaurant.getReviewCount());
        }

        [TestMethod]
        public void constructorShouldAllowReviewCountOneAboveMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 5, 1, "URL.com", "URL.com", "5");

            Assert.AreEqual(1, theRestaurant.getReviewCount());
        }

        [TestMethod]
        public void constructorShouldAllowReviewCountWellAboveMinimum() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 4, 5, 50, "URL.com", "URL.com", "5");

            Assert.AreEqual(50, theRestaurant.getReviewCount());
        }

        [TestMethod]
        public void constructorShouldNotAllowNullMenuURL() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, null, "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyMenuURL() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Pizza Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, null, "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidMenuURL() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "URL.com", "5");

            Assert.AreEqual("MenuURL.com", theRestaurant.getMenuURL());
        }

        [TestMethod]
        public void constructorShouldNotAllowNullImageURL() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", null, "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyImageURL() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidImageURL() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            Assert.AreEqual("ImageURL.com", theRestaurant.getImageURL());
        }

        [TestMethod]
        public void constructorShouldNotAllowNullId() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "imageURL.com", null));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyId() {
            Assert.ThrowsException<ArgumentException>(() => new Random_Restaurant_Picker.Models.Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "imageURL.com", ""));
        }

        [TestMethod]
        public void constructorShouldAllowValidId() {
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", 5, 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            Assert.AreEqual("5", theRestaurant.getId());
        }
    }
}
