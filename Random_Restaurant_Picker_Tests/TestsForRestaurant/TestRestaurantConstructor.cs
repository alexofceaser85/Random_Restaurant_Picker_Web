using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurant
{
    [TestClass]
    public class TestRestaurantConstructor
    {
        #region Methods

        [TestMethod]
        public void constructorShouldNotAllowNullName()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant(null, "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyName()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidName()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual("Matt's Pizza", theRestaurant.Name);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullPrice()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", null, "Senoia GA",
                "9:00 - 5:00", "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyPrice()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidPrice()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual("$$", theRestaurant.Price);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullLocation()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", null, "9:00 - 5:00",
                "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyLocation()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("Matt's Pizza", "$", "", "9:00 - 5:00", "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidLocation()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual("Senoia GA", theRestaurant.Location);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullHours()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("Matt's Pizza", "$", "Senoia GA", null, "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyHours()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("Matt's Pizza", "$", "Senoia GA", "", "5 Miles", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidHours()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual("9:00 - 5:00", theRestaurant.Hours);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullDistance()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", null, 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyDistance()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "", 4.5, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidDistance()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual("5 Miles", theRestaurant.Distance);
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreWellBelowMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", -50, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneBelowMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 0, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneTenthBelowMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", .9, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreAtMinimum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 1, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(1, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneTenthAboveMinimum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 1.1, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(1.1, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneAboveMinimum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 2, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(2, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreBetweenMinimumAndMaximum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 3.5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(3.5, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneBelowMaximum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(4, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreOneTenthBelowMaximum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.9, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(4.9, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldAllowReviewScoreAtMaximum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 5, 5,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(5, theRestaurant.ReviewScore);
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneTenthAboveMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 5.1, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreOneAboveMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 6, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewScoreWellAboveMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 50, 5, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewCountWellBelowMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 4, -50, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowReviewCountOneBelowMinimum()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Matt's Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 4, -1, "URL.com", "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowReviewCountAtMinimum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 5, 0,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(0, theRestaurant.ReviewCount);
        }

        [TestMethod]
        public void constructorShouldAllowReviewCountOneAboveMinimum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 5, 1,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(1, theRestaurant.ReviewCount);
        }

        [TestMethod]
        public void constructorShouldAllowReviewCountWellAboveMinimum()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 5, 50,
                "URL.com", "URL.com", "5");

            Assert.AreEqual(50, theRestaurant.ReviewCount);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullMenuURL()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, null, "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyMenuURL()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Pizza Pizza", "$", "Senoia GA",
                "9:00 - 5:00", "5 Miles", 4.5, 5, null, "URL.com", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidMenuURL()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "MenuURL.com", "URL.com", "5");

            Assert.AreEqual("MenuURL.com", theRestaurant.MenuUrl);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullImageURL()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", null, "5"));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyImageURL()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "", "5"));
        }

        [TestMethod]
        public void constructorShouldAllowValidImageURL()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "MenuURL.com", "ImageURL.com", "5");

            Assert.AreEqual("ImageURL.com", theRestaurant.ImageUrl);
        }

        [TestMethod]
        public void constructorShouldNotAllowNullId()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00",
                "5 Miles", 4.5, 5, "MenuURL.com", "imageURL.com", null));
        }

        [TestMethod]
        public void constructorShouldNotAllowEmptyId()
        {
            Assert.ThrowsException<ArgumentException>(() => new Restaurant("Pizza", "$", "Senoia GA", "9:00 - 5:00",
                "5 Miles", 4.5, 5, "MenuURL.com", "imageURL.com", ""));
        }

        [TestMethod]
        public void constructorShouldAllowValidId()
        {
            var theRestaurant = new Restaurant("Matt's Pizza", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5,
                "MenuURL.com", "ImageURL.com", "5");

            Assert.AreEqual("5", theRestaurant.Id);
        }

        #endregion
    }
}