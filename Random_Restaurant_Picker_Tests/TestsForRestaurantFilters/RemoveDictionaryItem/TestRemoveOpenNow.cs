using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveOpenNow {
        [TestMethod]
        public void ShouldNotRemoveOpenNowIfOpenNowIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOnlyOpenNowIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");

            theFilters.RemoveOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOpenNowIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddLocation("30254");
            theFilters.AddRadius("5");

            theFilters.RemoveOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "location 30254\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOpenNowIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("30254");
            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");

            theFilters.RemoveOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "location 30254\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveOpenNowIfOpenNowIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("30254");
            theFilters.AddRadius("5");
            theFilters.AddOpenNow("true");

            theFilters.RemoveOpenNow();

            Assert.AreEqual("Query Filters:\n"
                + "location 30254\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }
    }
}