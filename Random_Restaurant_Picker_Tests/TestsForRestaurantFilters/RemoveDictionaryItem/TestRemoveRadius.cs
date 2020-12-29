using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveRadius {
        [TestMethod]
        public void ShouldNotRemoveRadiusIfRadiusIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeRadius();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfOnlyRadiusIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addRadius("4");
            theFilters.removeRadius();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfRadiusIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addRadius("5");
            theFilters.addOpenNow("true");
            theFilters.addPrice("4");
            theFilters.removeRadius();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "price 4\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfRadiusIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addRadius("5");
            theFilters.addPrice("1");
            theFilters.removeRadius();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "price 1\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveRadiusIfRadiusIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addPrice("1");
            theFilters.addRadius("5");

            theFilters.removeRadius();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "price 1\n"
                + "Non Query Filters:\n", theFilters.toString());
        }
    }
}