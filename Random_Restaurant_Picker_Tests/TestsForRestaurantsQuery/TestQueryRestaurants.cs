using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;
using System.Net.Http;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantsQuery {
    [TestClass]
    public class ShouldReturnResultsForValidFilters {
        [TestMethod]
        public void TestMethod1Async() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.addLocation("Atlanta");
            theFilters.addRadius("8000");
            RestaurantManager theManager = new RestaurantManager();
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, theManager);
            theManager = theQuery.queryRestaurantsAsync();

            Assert.AreNotEqual(null, theManager.toString());
            Assert.AreNotEqual("", theManager.toString());
        }
    }

    [TestClass]
    public class ShouldNotReturnResultsForLocationFilters {
        [TestMethod]
        public void TestMethod1Async() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.addLocation("Atlanta");
            theFilters.addRadius("5");
            RestaurantManager theManager = new RestaurantManager();
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, theManager);
            theManager = theQuery.queryRestaurantsAsync();

            Assert.AreNotEqual(null, theManager.toString());
            Assert.AreEqual("", theManager.toString());
        }
    }
}
