using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveAttribute {

        [TestMethod]
        public void shouldNotAddNullAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.RemoveAttribute(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.RemoveAttribute(""));
        }

        [TestMethod]
        public void shouldNotRemoveAttributeIfAttributeIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.RemoveAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfMatchingAttributeIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("hot_and_new");
            theFilters.RemoveAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldNotRemoveAttributeIfNonMatchingAttributeIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("hot_and_new");
            theFilters.RemoveAttribute("reservation");

            Assert.AreEqual("Query Filters:\n"
                + "attributes hot_and_new\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldNotRemoveAttributeIfNonMatchingAttributesAreItemsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");
            theFilters.AddAttribute("hot_and_new");
            theFilters.AddAttribute("reservation");
            theFilters.RemoveAttribute("waitlist_reservation");

            Assert.AreEqual("Query Filters:\n"
                + "attributes wheelchair_accessible,hot_and_new,reservation\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveFirstAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");
            theFilters.AddAttribute("hot_and_new");
            theFilters.AddAttribute("reservation");
            theFilters.RemoveAttribute("wheelchair_accessible");

            Assert.AreEqual("Query Filters:\n"
                + "attributes hot_and_new,reservation\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveMiddleAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");
            theFilters.AddAttribute("hot_and_new");
            theFilters.AddAttribute("reservation");
            theFilters.RemoveAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
                + "attributes wheelchair_accessible,reservation\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveLastAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");
            theFilters.AddAttribute("hot_and_new");
            theFilters.AddAttribute("reservation");
            theFilters.RemoveAttribute("reservation");

            Assert.AreEqual("Query Filters:\n"
                + "attributes wheelchair_accessible,hot_and_new\n"
                + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfFirstElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("hot_and_new");
            theFilters.AddLocation("32515");
            theFilters.AddOpenNow("true");

            theFilters.RemoveAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfMiddleElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("hot_and_new");
            theFilters.AddLocation("32515");
            theFilters.AddOpenNow("true");

            theFilters.RemoveAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.ToString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfLastElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("hot_and_new");
            theFilters.AddLocation("32515");
            theFilters.AddOpenNow("true");

            theFilters.RemoveAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.ToString());
        }

    }
}
