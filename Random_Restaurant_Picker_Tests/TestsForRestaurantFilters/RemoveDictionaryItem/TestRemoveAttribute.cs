using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.RemoveDictionaryItem {
    [TestClass]
    public class TestRemoveAttribute {

        [TestMethod]
        public void shouldNotAddNullAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.removeAttribute(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.removeAttribute(""));
        }

        [TestMethod]
        public void shouldNotRemoveAttributeIfAttributeIsNotInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.removeAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfMatchingAttributeIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("hot_and_new");
            theFilters.removeAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldNotRemoveAttributeIfNonMatchingAttributeIsOnlyItemInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("hot_and_new");
            theFilters.removeAttribute("reservation");

            Assert.AreEqual("Query Filters:\n"
                + "attributes hot_and_new\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldNotRemoveAttributeIfNonMatchingAttributesAreItemsInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");
            theFilters.addAttribute("hot_and_new");
            theFilters.addAttribute("reservation");
            theFilters.removeAttribute("waitlist_reservation");

            Assert.AreEqual("Query Filters:\n"
                + "attributes wheelchair_accessible,hot_and_new,reservation\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveFirstAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");
            theFilters.addAttribute("hot_and_new");
            theFilters.addAttribute("reservation");
            theFilters.removeAttribute("wheelchair_accessible");

            Assert.AreEqual("Query Filters:\n"
                + "attributes hot_and_new,reservation\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveMiddleAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");
            theFilters.addAttribute("hot_and_new");
            theFilters.addAttribute("reservation");
            theFilters.removeAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
                + "attributes wheelchair_accessible,reservation\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveLastAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");
            theFilters.addAttribute("hot_and_new");
            theFilters.addAttribute("reservation");
            theFilters.removeAttribute("reservation");

            Assert.AreEqual("Query Filters:\n"
                + "attributes wheelchair_accessible,hot_and_new\n"
                + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfFirstElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("hot_and_new");
            theFilters.addLocation("32515");
            theFilters.addOpenNow("true");

            theFilters.removeAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfMiddleElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("hot_and_new");
            theFilters.addLocation("32515");
            theFilters.addOpenNow("true");

            theFilters.removeAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.toString());
        }

        [TestMethod]
        public void shouldRemoveAttributeIfLastElementInDictionary() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("hot_and_new");
            theFilters.addLocation("32515");
            theFilters.addOpenNow("true");

            theFilters.removeAttribute("hot_and_new");

            Assert.AreEqual("Query Filters:\n"
            + "location 32515\n"
            + "open_now true\n"
            + "Non Query Filters:\n", theFilters.toString());
        }

    }
}
