using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Data;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestRestaurantQueryUtils {
    [TestClass]
    public class TestAssembleQueryString {
        [TestMethod]
        public void ShouldAssembleQueryStringWithoutFilters() {
            RestaurantsQuery theQuery = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());
            Assert.AreEqual("https://api.yelp.com/v3/businesses/search?", theQuery.AssembleQueryString());
        }

        [TestMethod]
        public void ShouldAssembleQueryStringWithOneFilter() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.AddLocation("Atlanta, GA");
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, new RestaurantManager());
            Assert.AreEqual("https://api.yelp.com/v3/businesses/search?location=Atlanta, GA", theQuery.AssembleQueryString());
        }

        [TestMethod]
        public void ShouldAssembleQueryStringWithManyFilters() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.AddLocation("Atlanta, GA");
            theFilters.AddOpenNow("true");
            theFilters.AddRadius("8000");
            theFilters.AddPrice("1");
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, new RestaurantManager());
            Assert.AreEqual("https://api.yelp.com/v3/businesses/search?location=Atlanta, GA&open_now=true&radius=8000&price=1", theQuery.AssembleQueryString());
        }
    }
}
