using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters {
    [TestClass]
    public class TestAddOpenNow {

        [TestMethod]
        public void shouldNotAddNullOpenNow() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addOpenNow(null));
        }

        [TestMethod]
        public void shouldNotAddEmptyOpenNow() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addOpenNow(""));
        }

        [TestMethod]
        public void shouldNotAddOpenNowWithInvalidNumberValue() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addOpenNow("15"));
        }

        [TestMethod]
        public void shouldNotAddOpenNowWithInvalidLetterValue() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Assert.ThrowsException<ArgumentException>(() => theFilters.addOpenNow("Invalid Letters"));
        }

        [TestMethod]
        public void shouldAddOpenNowWithValidLetterValue() {

            RestaurantFilters theFilters = new RestaurantFilters();

            theFilters.addOpenNow("true");

            Assert.AreEqual("Query Filters:\n"
            + "open_now true\n"
            + "Non Query Filters:\n"
            , theFilters.toString());
        }
    }
}
