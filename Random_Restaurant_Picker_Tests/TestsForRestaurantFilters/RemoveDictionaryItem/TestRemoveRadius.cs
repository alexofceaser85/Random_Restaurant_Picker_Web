using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveRadius {
        [TestMethod]
        public void ShouldNotRemoveRadiusIfRadiusIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveRadius();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfOnlyRadiusIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddRadius("4");
            theFilters.RemoveRadius();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfRadiusIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddRadius("5");
            theFilters.AddOpenNow("true");
            theFilters.AddPrice("4");
            theFilters.RemoveRadius();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "price 4\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfRadiusIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");
            theFilters.AddPrice("1");
            theFilters.RemoveRadius();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "price 1\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfRadiusIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddPrice("1");
            theFilters.AddRadius("5");

            theFilters.RemoveRadius();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "price 1\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }
    }
}