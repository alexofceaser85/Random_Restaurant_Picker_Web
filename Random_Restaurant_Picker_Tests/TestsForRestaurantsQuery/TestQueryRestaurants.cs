using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Random_Restaurant_Picker.Data;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantsQuery
{
    [TestClass]
    public class TestQueryRestaurants {

        [TestMethod]
        public void ShouldReturnNullForInvalidQuery() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.AddLocation("Atlanta");
            theFilters.AddRadius("5");
            RestaurantManager theManager = new RestaurantManager();
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, theManager);

            Assert.AreEqual(null, theQuery.QueryRestaurants("Invalid Query"));
        }

        [TestMethod]
        public void ShouldNotReturnResultsForInvalidFilters() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.AddLocation("Atlanta");
            theFilters.AddRadius("5");
            RestaurantManager theManager = new RestaurantManager();
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, theManager);

            string queryString = theQuery.AssembleQueryString();
            JArray queriedRestaurants = theQuery.QueryRestaurants(queryString);

            Assert.AreNotEqual(null, theManager = theQuery.PopulateRestaurants(queriedRestaurants));
            Assert.AreNotEqual(null, theManager.ToString());
            Assert.AreEqual("", theManager.ToString());
        }

        [TestMethod]
        public void ShouldReturnResultsForValidFilters() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.AddLocation("Atlanta");
            theFilters.AddRadius("8000");
            RestaurantManager theManager = new RestaurantManager();
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, theManager);

            string queryString = theQuery.AssembleQueryString();
            JArray queriedRestaurants = theQuery.QueryRestaurants(queryString);

            Assert.AreNotEqual(null, theManager = theQuery.PopulateRestaurants(queriedRestaurants));
            Assert.AreNotEqual(null, theManager.ToString());
            Assert.AreNotEqual("", theManager.ToString());
        }
    }
}