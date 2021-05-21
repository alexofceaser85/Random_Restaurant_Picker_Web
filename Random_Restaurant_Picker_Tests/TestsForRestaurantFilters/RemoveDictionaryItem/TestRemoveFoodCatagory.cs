using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveFoodCatagory {
        [TestMethod]
        public void ShouldNotRemoveFoodCatagoryIfFoodCatagoryIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveFoodCategory();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfOnlyFoodCatagoryIsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddFoodCategory("30254");

            theFilters.RemoveFoodCategory();

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfFoodCatagoryIsFirstItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddFoodCategory("Burgers");
            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");

            theFilters.RemoveFoodCategory();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfFoodCatagoryIsMiddleItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddFoodCategory("Burgers");
            theFilters.AddRadius("5");

            theFilters.RemoveFoodCategory();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void ShouldRemoveFoodCatagoryIfFoodCatagoryIsLastItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");
            theFilters.AddRadius("5");
            theFilters.AddFoodCategory("Burgers");

            theFilters.RemoveFoodCategory();

            Assert.AreEqual("Query Filters:\n"
                + "open_now true\n"
                + "radius 5\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }
    }
}