using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.AddDictionaryItem {
    [TestClass]
    public class TestAddTerm {
        [TestMethod]
        public void shouldNotAddNullTerm() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddTerm(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyTerm() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddTerm(""));
        }

        [TestMethod]
        public void shouldNotAddDuplicateTerms() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddTerm("burgers");

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddTerm("chinese"));
        }

        [TestMethod]
        public void shouldAddOneTerm() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddTerm("burgers");

            Assert.AreEqual("Query Filters:\n"
            + "term burgers\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }
    }
}
