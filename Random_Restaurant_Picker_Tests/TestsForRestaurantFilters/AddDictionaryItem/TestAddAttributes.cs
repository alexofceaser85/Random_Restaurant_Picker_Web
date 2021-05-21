using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.AddDictionaryItem {
    [TestClass]
    public class TestAddAttributes {

        [TestMethod]
        public void shouldNotAddNullAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddAttribute(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddAttribute(""));
        }

        [TestMethod]
        public void shouldAddOneAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");

            Assert.AreEqual("Query Filters:\n"
            + "attributes wheelchair_accessible\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldAddManyAttributes() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");
            theFilters.AddAttribute("hot_and_new");
            theFilters.AddAttribute("reservation");

            Assert.AreEqual("Query Filters:\n"
            + "attributes wheelchair_accessible,hot_and_new,reservation\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }

        [TestMethod]
        public void shouldNotAddDuplicateAttributes() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddAttribute("wheelchair_accessible");
            theFilters.AddAttribute("wheelchair_accessible");

            Assert.AreEqual("Query Filters:\n"
            + "attributes wheelchair_accessible\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }
    }
}
