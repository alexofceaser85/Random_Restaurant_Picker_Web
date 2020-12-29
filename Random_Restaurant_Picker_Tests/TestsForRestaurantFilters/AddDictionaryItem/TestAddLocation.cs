using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddLocation {
        [TestMethod]
        public void shouldNotAddNullLocation() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addLocation(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyLocation() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addLocation(""));
        }

        [TestMethod]
        public void shouldNotAddDuplicateLocations() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("2021 N 4th St #100, Coeur d'Alene, ID 83814");

            Assert.ThrowsException<ArgumentException>(() => theFilters.addLocation("New York"));
        }

        [TestMethod]
        public void shouldAddOneLocation() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("2021 N 4th St #100, Coeur d'Alene, ID 83814");

            Assert.AreEqual("Query Filters:\n"
            + "location 2021 N 4th St #100, Coeur d'Alene, ID 83814\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }
    }
}
