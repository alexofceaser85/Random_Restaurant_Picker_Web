using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.AddDictionaryItem {
    [TestClass]
    public class TestAddPrice {

        [TestMethod]
        public void shouldNotAddNullPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice(""));
        }

        [TestMethod]
        public void shouldNotAddInvalidPriceAsSpecialCharactor() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("$"));
        }

        [TestMethod]
        public void shouldNotAddInvalidPriceAsLetter() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("One Price Score"));
        }

        [TestMethod]
        public void shouldNotAddPriceNotSeperateByCommas() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("1 2 3"));
        }

        [TestMethod]
        public void shouldNotAddPriceWellAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("50"));
        }

        [TestMethod]
        public void shouldNotAddPriceOneAboveMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("5"));
        }

        [TestMethod]
        public void shouldNotAddPriceOneBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("0"));
        }

        [TestMethod]
        public void shouldNotAddPriceWellBelowMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddPrice("-50"));
        }

        [TestMethod]
        public void shouldAddPriceOnce() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddPriceAtMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddPriceOneAboveMinimum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("2");

            Assert.AreEqual("Query Filters:\n"
            + "price 2\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddPriceAtMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("4");

            Assert.AreEqual("Query Filters:\n"
            + "price 4\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddPriceOneBelowMaximum() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("3");

            Assert.AreEqual("Query Filters:\n"
            + "price 3\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldNotAddMultipleDuplicatePrices() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddMultipleNonDuplicatePrices() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddPrice("2");

            Assert.AreEqual("Query Filters:\n"
            + "price 1,2\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddMultipleCommaSeperatePrices() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1,2,3");

            Assert.AreEqual("Query Filters:\n"
            + "price 1,2,3\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]

        public void shouldSortPrices() {
            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("3");
            theFilters.AddPrice("2");
            theFilters.AddPrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "price 1,2,3\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }
    }
}
