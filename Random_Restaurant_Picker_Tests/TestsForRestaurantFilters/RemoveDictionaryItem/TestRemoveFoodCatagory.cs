using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveFoodCatagory {
        [TestMethod]
        public void ShouldNotRemoveFoodCatagoryIfFoodCatagoryIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeFoodCatagory();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfOnlyFoodCatagoryIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addFoodCatagory("30254");

            theFilters.removeFoodCatagory();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfFoodCatagoryIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addFoodCatagory("Burgers");
            theFilters.addOpenNow("true");
            theFilters.addRadius("5");

            theFilters.removeFoodCatagory();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfFoodCatagoryIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addFoodCatagory("Burgers");
            theFilters.addRadius("5");

            theFilters.removeFoodCatagory();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfFoodCatagoryIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");
            theFilters.addRadius("5");
            theFilters.addFoodCatagory("Burgers");

            theFilters.removeFoodCatagory();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.toString());
        }
    }
}