using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveLocation {
        [TestMethod]
        public void ShouldNotRemoveLocationIfLocationIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeLocation();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfOnlyLocationIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("30254");

            theFilters.removeLocation();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfLocationIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("30254");
            theFilters.addOpenNow("true");
            theFilters.addRadius("5");

            theFilters.removeLocation();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfLocationIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addLocation("30254");
            theFilters.addRadius("5");

            theFilters.removeLocation();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveLocationIfLocationIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addRadius("5");
            theFilters.addLocation("30254");

            theFilters.removeLocation();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }
    }
}