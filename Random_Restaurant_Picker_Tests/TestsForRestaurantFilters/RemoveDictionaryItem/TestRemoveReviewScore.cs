using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveReviewScore {
        [TestMethod]
        public void ShouldNotRemoveReviewScoreIfReviewScoreIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfOnlyReviewScoreIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("4");

            theFilters.removeReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfReviewScoreIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addReviewScore("4");
            theFilters.addOpenNow("true");
            theFilters.addRadius("5");

            theFilters.removeReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfReviewScoreIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addReviewScore("4");
            theFilters.addRadius("5");

            theFilters.removeReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveReviewScoreIfReviewScoreIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addRadius("5");
            theFilters.addReviewScore("4");

            theFilters.removeReviewScore();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }
    }
}