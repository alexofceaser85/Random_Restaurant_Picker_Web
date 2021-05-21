using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveTerm {
        [TestMethod]
        public void ShouldNotRemoveTermIfTermIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveTerm();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfOnlyTermIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddTerm("Restaurants");
            theFilters.RemoveTerm();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfTermIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddTerm("Restaurants");
            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");
            theFilters.RemoveTerm();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfTermIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddTerm("Restaurants");
            theFilters.AddRadius("5");
            theFilters.RemoveTerm();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveTermIfTermIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");
            theFilters.AddTerm("Restaurants");

            theFilters.RemoveTerm();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }
    }
}
