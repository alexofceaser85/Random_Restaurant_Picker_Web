using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddFoodCatagory {
        [TestMethod]
        public void shouldNotAddNullFoodCatagory() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addFoodCatagory(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyFoodCatagory() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addFoodCatagory(""));
        }

        [TestMethod]
        public void shouldNotAddDuplicateFoodCatagorys() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addFoodCatagory("Burgers");

            Assert.ThrowsException<ArgumentException>(() => theFilters.addFoodCatagory("Fried Chicken"));
        }

        [TestMethod]
        public void shouldAddOneFoodCatagory() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addFoodCatagory("Burgers");

            Assert.AreEqual("Query Filters:\n"
            + "categories Burgers\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }
    }
}
