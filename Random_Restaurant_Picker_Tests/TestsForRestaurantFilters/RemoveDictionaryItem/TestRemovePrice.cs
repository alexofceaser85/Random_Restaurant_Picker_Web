using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemovePrice {

        [TestMethod]
        public void shouldNotAddNullPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.RemovePrice(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.RemovePrice(""));
        }

        [TestMethod]
        public void shouldNotRemovePriceIfPriceIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemovePrice("$");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemovePriceIfMatchingPriceIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.RemovePrice("1");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldNotRemovePriceIfNonMatchingPriceIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.RemovePrice("2");

            Assert.AreEqual("Query Filters:\n"
                + "price 1\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldNotRemovePriceIfNonMatchingPricesAreItemsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddPrice("3");
            theFilters.AddPrice("4");
            theFilters.RemovePrice("2");

            Assert.AreEqual("Query Filters:\n"
                + "price 1,3,4\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveFirstPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddPrice("3");
            theFilters.AddPrice("4");
            theFilters.RemovePrice("1");

            Assert.AreEqual("Query Filters:\n"
                + "price 3,4\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveMiddlePrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddPrice("3");
            theFilters.AddPrice("4");
            theFilters.RemovePrice("3");

            Assert.AreEqual("Query Filters:\n"
                + "price 1,4\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveLastPrice() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddPrice("3");
            theFilters.AddPrice("4");
            theFilters.RemovePrice("4");

            Assert.AreEqual("Query Filters:\n"
                + "price 1,3\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemovePriceIfFirstElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddPrice("1");
            theFilters.AddLocation("32515");
            theFilters.AddOpenNow("true");

            theFilters.RemovePrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemovePriceIfMiddleElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("32515");
            theFilters.AddPrice("1");
            theFilters.AddOpenNow("true");

            theFilters.RemovePrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemovePriceIfLastElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddLocation("32515");
            theFilters.AddOpenNow("true");
            theFilters.AddPrice("1");

            theFilters.RemovePrice("1");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.ToString());
        }

    }
}
