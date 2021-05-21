using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveReviewScore {
        [TestMethod]
        public void ShouldNotRemoveReviewScoreIfReviewScoreIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfOnlyReviewScoreIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddReviewScore("4");

            theFilters.RemoveReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfReviewScoreIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddReviewScore("4");
            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");

            theFilters.RemoveReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfReviewScoreIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddReviewScore("4");
            theFilters.AddRadius("5");

            theFilters.RemoveReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfReviewScoreIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");
            theFilters.AddReviewScore("4");

            theFilters.RemoveReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }
    }
}