using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveLocation {
        [TestMethod]
        public void ShouldNotRemoveLocationIfLocationIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveLocation();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfOnlyLocationIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("30254");

            theFilters.RemoveLocation();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfLocationIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("30254");
            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");

            theFilters.RemoveLocation();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfLocationIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddLocation("30254");
            theFilters.AddRadius("5");

            theFilters.RemoveLocation();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfLocationIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");
            theFilters.AddLocation("30254");

            theFilters.RemoveLocation();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }
    }
}