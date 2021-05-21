using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantFilters.OtherTests {
    [TestClass]
    public class TestGetQueryFilters {
        [TestMethod]
        public void shouldGetQueryFilters() {

            RestaurantFilters theFilters = new RestaurantFilters();

            Dictionary<String, String> filtersDictionary = theFilters.GetQueryFilters();

            filtersDictionary.Add("Added", "Successfully");
            String verifyString = "";

            foreach(String key in filtersDictionary.Keys) {
                verifyString += key + "=" + filtersDictionary[key]; 
            }

            Assert.AreEqual("Added=Successfully", verifyString);
        }
    }
}
