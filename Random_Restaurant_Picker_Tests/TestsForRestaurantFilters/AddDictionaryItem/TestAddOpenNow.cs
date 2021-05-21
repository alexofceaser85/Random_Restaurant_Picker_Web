using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.AddDictionaryItem {
    [TestClass]
    public class TestAddOpenNow {

        [TestMethod]
        public void shouldNotAddNullOpenNow() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddOpenNow(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyOpenNow() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddOpenNow(""));
        }

        [TestMethod]
        public void shouldNotAddOpenNowWithInvalidNumberValue() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddOpenNow("15"));
        }

        [TestMethod]
        public void shouldNotAddOpenNowWithInvalidLetterValue() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.AddOpenNow("Invalid Letters"));
        }

        [TestMethod]
        public void shouldAddOpenNowWithValidLetterValue() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.AddOpenNow("true");

            Assert.AreEqual("Query Filters:\n"
            + "open_now true\n"
            + "Non Query Filters:\n"
            , theFilters.ToString());
        }
    }
}
