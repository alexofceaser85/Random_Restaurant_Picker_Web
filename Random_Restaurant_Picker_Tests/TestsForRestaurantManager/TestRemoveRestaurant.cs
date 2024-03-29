﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantManager {
    [TestClass]
    public class TestRemoveRestaurant {
        [TestMethod]
        public void shouldNotRemoveNullRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Assert.ThrowsException<ArgumentException>(() => theManager.RemoveRestaurant(null));
        }

        [TestMethod]
        public void shouldNotRemoveRestaurantFromEmptyManager() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            theManager.RemoveRestaurant(theRestaurant);

            Assert.AreEqual("", theManager.ToString());
        }

        [TestMethod]
        public void shouldRemoveRestaurantFromManagerWithOneMatchingRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant theRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");

            theManager.AddRestaurant(theRestaurant);
            theManager.RemoveRestaurant(theRestaurant);

            Assert.AreEqual("", theManager.ToString());
        }

        [TestMethod]
        public void shouldNotRemoveRestaurantFromManagerWithOneNotMatchingRestaurant() {
            RestaurantManager theManager = new RestaurantManager();
            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");

            theManager.AddRestaurant(firstRestaurant);
            theManager.RemoveRestaurant(secondRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 Miles review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)\n", theManager.ToString());
        }

        [TestMethod]
        public void shouldNotRemoveRestaurantFromManagerWithManyNotMatchingRestaurants() {
            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "770-644-4488", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");
            Restaurant fourthRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Jacob's Table", "770-644-4488", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "8");

            theManager.AddRestaurant(firstRestaurant);
            theManager.AddRestaurant(secondRestaurant);
            theManager.AddRestaurant(thirdRestaurant);

            theManager.RemoveRestaurant(fourthRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 Miles review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)\n"
                + "Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)\n"
                + "Restaurant (name: Senoia Coffee price: $$ location: Senoia GA hours: 9:00 - 2:00 distance: 25 Miles review score: 5 review count: 0 menu URL: MenuURL.com image URL: ImageURL.com id: 7)\n", theManager.ToString());
        }

        [TestMethod]
        public void shouldRemoveFirstRestaurantOfMany() {
            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "770-644-4488", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.AddRestaurant(firstRestaurant);
            theManager.AddRestaurant(secondRestaurant);
            theManager.AddRestaurant(thirdRestaurant);

            theManager.RemoveRestaurant(firstRestaurant);

            Assert.AreEqual("Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)\n"
                + "Restaurant (name: Senoia Coffee price: $$ location: Senoia GA hours: 9:00 - 2:00 distance: 25 Miles review score: 5 review count: 0 menu URL: MenuURL.com image URL: ImageURL.com id: 7)\n", theManager.ToString());
        }

        [TestMethod]
        public void shouldRemoveMiddleRestaurantOfMany() {
            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "770-644-4488", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.AddRestaurant(firstRestaurant);
            theManager.AddRestaurant(secondRestaurant);
            theManager.AddRestaurant(thirdRestaurant);

            theManager.RemoveRestaurant(secondRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 Miles review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)\n"
                + "Restaurant (name: Senoia Coffee price: $$ location: Senoia GA hours: 9:00 - 2:00 distance: 25 Miles review score: 5 review count: 0 menu URL: MenuURL.com image URL: ImageURL.com id: 7)\n", theManager.ToString());
        }

        [TestMethod]
        public void shouldRemoveLastRestaurantOfMany() {
            RestaurantManager theManager = new RestaurantManager();

            Restaurant firstRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Matt's Pizza", "770-644-4488", "$", "Senoia GA", "9:00 - 5:00", "5 Miles", 4.5, 5, "MenuURL.com", "ImageURL.com", "5");
            Restaurant secondRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Katy Lou's", "770-644-4488", "$$$", "Senoia GA", "8:00 - 6:00", "0 Miles", 4.9, 3, "MenuURL.com", "ImageURL.com", "6");
            Restaurant thirdRestaurant = new Random_Restaurant_Picker.Models.Restaurant("Senoia Coffee", "770-644-4488", "$$", "Senoia GA", "9:00 - 2:00", "25 Miles", 5, 0, "MenuURL.com", "ImageURL.com", "7");

            theManager.AddRestaurant(firstRestaurant);
            theManager.AddRestaurant(secondRestaurant);
            theManager.AddRestaurant(thirdRestaurant);

            theManager.RemoveRestaurant(thirdRestaurant);

            Assert.AreEqual("Restaurant (name: Matt's Pizza price: $ location: Senoia GA hours: 9:00 - 5:00 distance: 5 Miles review score: 4.5 review count: 5 menu URL: MenuURL.com image URL: ImageURL.com id: 5)\n"
                + "Restaurant (name: Katy Lou's price: $$$ location: Senoia GA hours: 8:00 - 6:00 distance: 0 Miles review score: 4.9 review count: 3 menu URL: MenuURL.com image URL: ImageURL.com id: 6)\n", theManager.ToString());
        }
    }
}
