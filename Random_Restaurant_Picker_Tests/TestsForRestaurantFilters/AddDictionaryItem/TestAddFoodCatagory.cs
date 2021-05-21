using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.AddDictionaryItem {
    [TestClass]
    public class TestAddFoodCatagory {
        [TestMethod]
        public void shouldNotAddNullFoodCatagory() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddFoodCategory(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyFoodCatagory() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddFoodCategory(""));
        }

        [TestMethod]
        public void shouldNotAddDuplicateFoodCatagorys() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddFoodCategory("Burgers");

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddFoodCategory("Fried Chicken"));
        }

        [TestMethod]
        public void shouldAddOneFoodCatagory() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddFoodCategory("Burgers");

            Assert.AreEqual("Query Filters:\n"
            + "categories Burgers\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }
    }
}
