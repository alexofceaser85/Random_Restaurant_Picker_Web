using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddReviewScore {

        [TestMethod]
        public void shouldNotAddNullReviewScore() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyReviewScore() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore(""));
        }

        [TestMethod]
        public void shouldNotAllowLettersInReviewScore() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("Score of 4"));
        }

        [TestMethod]
        public void shouldNotAllowSymbolsInReviewScore() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("4%"));
        }

        [TestMethod]
        public void shouldNotAddReviewScoreWellBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("-50"));
        }

        [TestMethod]
        public void shouldNotAddReviewScoreOneBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("0"));
        }

        [TestMethod]
        public void shouldNotAddReviewScoreOneTenthBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("0.9"));
        }

        [TestMethod]
        public void shouldNotAddReviewScoreOneTenthAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("5.1"));
        }

        [TestMethod]
        public void shouldNotAddReviewScoreOneAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("6"));
        }

        [TestMethod]
        public void shouldNotAddReviewScoreWellAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addReviewScore("50"));
        }

        [TestMethod]
        public void shouldAddReviewScoreAtMinimumAsInteger() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("1");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 1\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreAtMinimumAsDouble() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("1.0");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 1.0\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreOneTenthAboveMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("1.1");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 1.1\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreOneAboveMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("2");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 2\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreOneTenthBelowMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("4.9");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 4.9\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreOneBelowMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("4");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 4\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreAtMaximumAsInteger() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("5");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 5\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddReviewScoreAtMaximumAsDouble() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("5.0");

            Assert.AreEqual("Query Filters:\n"
            + "Non Query Filters:\n"
            + "review_score 5.0\n"
            , theFilters.toString());
        }
    }
}
