using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddRadius {
        [TestMethod]
        public void shouldNotAddNullRadius() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addRadius(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyRadius() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addRadius(""));
        }

        [TestMethod]
        public void shouldNotAddRadiusWithLetters() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addRadius("10 Miles"));

        }

        [TestMethod]
        public void shouldNotAddRadiusWithSymbols() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addRadius("10%"));

        }

        [TestMethod]
        public void shouldNotAddDuplicateRadius() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addRadius("25");

            Assert.ThrowsException<ArgumentException>(() => theFilters.addRadius("5"));
        }

        [TestMethod]
        public void shouldAddOneRadiusAtMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addRadius("0");

            Assert.AreEqual("Query Filters:\n"
            + "radius 0\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddOneRadiusNearMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addRadius("25");

            Assert.AreEqual("Query Filters:\n"
            + "radius 25\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddOneRadiusWellAboveMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addRadius("25000");

            Assert.AreEqual("Query Filters:\n"
            + "radius 25000\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }
    }
}
