using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddAttributes {

        [TestMethod]
        public void shouldNotAddNullAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addAttribute(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addAttribute(""));
        }

        [TestMethod]
        public void shouldAddOneAttribute() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");

            Assert.AreEqual("Query Filters:\n"
            + "attributes wheelchair_accessible\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldAddManyAttributes() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");
            theFilters.addAttribute("hot_and_new");
            theFilters.addAttribute("reservation");

            Assert.AreEqual("Query Filters:\n"
            + "attributes wheelchair_accessible,hot_and_new,reservation\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }

        [TestMethod]
        public void shouldNotAddDuplicateAttributes() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addAttribute("wheelchair_accessible");
            theFilters.addAttribute("wheelchair_accessible");

            Assert.AreEqual("Query Filters:\n"
            + "attributes wheelchair_accessible\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }
    }
}
