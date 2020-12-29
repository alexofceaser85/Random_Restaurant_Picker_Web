using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveTerm {
        [TestMethod]
        public void ShouldNotRemoveTermIfTermIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeTerm();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfOnlyTermIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addTerm("Restaurants");
            theFilters.removeTerm();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfTermIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addTerm("Restaurants");
            theFilters.addOpenNow("true");
            theFilters.addRadius("5");
            theFilters.removeTerm();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfTermIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addTerm("Restaurants");
            theFilters.addRadius("5");
            theFilters.removeTerm();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfTermIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addRadius("5");
            theFilters.addTerm("Restaurants");

            theFilters.removeTerm();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }
    }
}
