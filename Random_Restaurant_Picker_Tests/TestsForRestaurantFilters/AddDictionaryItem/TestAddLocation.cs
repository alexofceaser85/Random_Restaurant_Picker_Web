using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.AddDictionaryItem {
    [TestClass]
    public class TestAddLocation {
        [TestMethod]
        public void shouldNotAddNullLocation() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddLocation(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyLocation() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddLocation(""));
        }

        [TestMethod]
        public void shouldNotAddDuplicateLocations() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("2021 N 4th St #100, Coeur d'Alene, ID 83814");

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddLocation("New York"));
        }

        [TestMethod]
        public void shouldAddOneLocation() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("2021 N 4th St #100, Coeur d'Alene, ID 83814");

            Assert.AreEqual("Query Filters:\n"
            + "location 2021 N 4th St #100, Coeur d'Alene, ID 83814\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }
    }
}
