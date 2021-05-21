using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantsQuery
{
    [TestClass]
    public class ShouldNotReturnResultsForLocationFilters {
        [TestMethod]
        public void TestMethod1Async() {
            RestaurantFilters theFilters = new RestaurantFilters();
            theFilters.AddLocation("Atlanta");
            theFilters.AddRadius("5");
            RestaurantManager theManager = new RestaurantManager();
            RestaurantsQuery theQuery = new RestaurantsQuery(theFilters, theManager);
            theManager = theQuery.queryRestaurantsAsync();

            Assert.AreNotEqual(null, theManager.toString());
            Assert.AreEqual("", theManager.toString());
        }
    }
}