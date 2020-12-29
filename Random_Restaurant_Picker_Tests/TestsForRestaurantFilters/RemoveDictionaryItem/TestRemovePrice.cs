using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemovePrice {

        [TestMethod]
        public void shouldNotAddNullPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.removePrice(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.removePrice(""));
        }

        [TestMethod]
        public void shouldNotRemovePriceIfPriceIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removePrice("$");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemovePriceIfMatchingPriceIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.removePrice("1");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldNotRemovePriceIfNonMatchingPriceIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.removePrice("2");

            Assert.AreEqual("Query Filters:\n"
                + "price 1\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldNotRemovePriceIfNonMatchingPricesAreItemsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addPrice("3");
            theFilters.addPrice("4");
            theFilters.removePrice("2");

            Assert.AreEqual("Query Filters:\n"
                + "price 1,3,4\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveFirstPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addPrice("3");
            theFilters.addPrice("4");
            theFilters.removePrice("1");

            Assert.AreEqual("Query Filters:\n"
                + "price 3,4\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveMiddlePrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addPrice("3");
            theFilters.addPrice("4");
            theFilters.removePrice("3");

            Assert.AreEqual("Query Filters:\n"
                + "price 1,4\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveLastPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addPrice("3");
            theFilters.addPrice("4");
            theFilters.removePrice("4");

            Assert.AreEqual("Query Filters:\n"
                + "price 1,3\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemovePriceIfFirstElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addPrice("1");
            theFilters.addLocation("32515");
            theFilters.addOpenNow("true");

            theFilters.removePrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemovePriceIfMiddleElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("32515");
            theFilters.addPrice("1");
            theFilters.addOpenNow("true");

            theFilters.removePrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemovePriceIfLastElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addLocation("32515");
            theFilters.addOpenNow("true");
            theFilters.addPrice("1");

            theFilters.removePrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.toString());
        }

    }
}
