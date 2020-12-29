using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveOpenNow {
        [TestMethod]
        public void ShouldNotRemoveOpenNowIfOpenNowIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOnlyOpenNowIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");

            theFilters.removeOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOpenNowIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addLocation("30254");
            theFilters.addRadius("5");

            theFilters.removeOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "location 30254\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOpenNowIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("30254");
            theFilters.addOpenNow("true");
            theFilters.addRadius("5");

            theFilters.removeOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "location 30254\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOpenNowIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("30254");
            theFilters.addRadius("5");
            theFilters.addOpenNow("true");

            theFilters.removeOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "location 30254\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }
    }
}