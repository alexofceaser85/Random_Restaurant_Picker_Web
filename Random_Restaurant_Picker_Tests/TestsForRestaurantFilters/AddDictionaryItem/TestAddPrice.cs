using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddPrice {

        [TestMethod]
        public void shouldNotAddNullPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice(""));
        }

        [TestMethod]
        public void shouldNotAddInvalidPriceAsSpecialCharactor() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("$"));
        }

        [TestMethod]
        public void shouldNotAddInvalidPriceAsLetter() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("One Price Score"));
        }

        [TestMethod]
        public void shouldNotAddPriceNotSeperateByCommas() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("1 2 3"));
        }

        [TestMethod]
        public void shouldNotAddPriceWellAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("50"));
        }

        [TestMethod]
        public void shouldNotAddPriceOneAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("5"));
        }

        [TestMethod]
        public void shouldNotAddPriceOneBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("0"));
        }

        [TestMethod]
        public void shouldNotAddPriceWellBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addPrice("-50"));
        }

        [TestMethod]
        public void shouldAddPriceOnce() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddPriceAtMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddPriceOneAboveMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("2");

            Assert.AreEqual("Query Filters:\n"
            + "price 2\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddPriceAtMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("4");

            Assert.AreEqual("Query Filters:\n"
            + "price 4\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddPriceOneBelowMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("3");

            Assert.AreEqual("Query Filters:\n"
            + "price 3\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldNotAddMultipleDuplicatePrices() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddMultipleNonDuplicatePrices() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addPrice("2");

            Assert.AreEqual("Query Filters:\n"
            + "price 1,2\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddMultipleCommaSeperatePrices() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1,2,3");

            Assert.AreEqual("Query Filters:\n"
            + "price 1,2,3\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]

        public void shouldSortPrices() {
            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("3");
            theFilters.addPrice("2");
            theFilters.addPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1,2,3\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }
    }
}
