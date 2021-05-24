using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Random_Restaurant_Picker.Data;
using Random_Restaurant_Picker.ErrorMessages;
using Random_Restaurant_Picker.Models;

namespace Random_Restaurant_Picker_Tests.TestsForRestaurantsQuery {
    [TestClass]
    public class TestPopulateRestaurants {

        [TestMethod]
        public void ShouldNotPopulateIfDataIsNull() {
            RestaurantsQuery theQuery = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            Assert.ThrowsException<ArgumentException>(() => theQuery.PopulateRestaurants(null));
        }

        [TestMethod]
        public void ShouldPopulateForOneValidRestaurantData() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                            ],
                        'price': '$',
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray) firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual(
                "Restaurant (name: Sublime Doughnuts price: $ location: 535 10th St NW, Atlanta, GA 30318 hours:  distance: 4569.2202838849535 review score: 4 review count: 1167 menu URL: https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg id: iG8DnZCnKHH_KYC8pG14NQ)\n",
                thePopulatedManager.ToString());
        }

        [TestMethod]
        public void ShouldPopulateForManyValidRestaurantData() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                         ],
                        'price': '$',
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }, 
                    {
                        'id': 'W2uLX3tc3YrhKKxEIPRmAw',
                        'alias': 'georgia-aquarium-atlanta',
                        'name': 'Georgia Aquarium',
                        'image_url': 'https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '2684',
                        'categories': [
                            {
                                'alias': 'aquariums',
                                'title': 'Aquariums'
                            }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.7630463019815',
                            'longitude': '-84.3947916838531'
                        },
                        'transactions': [],
                        'price': '$$',
                        'location': {
                            'address1': '225 Baker St',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30313',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '225 Baker St',
                               'Atlanta, GA 30313'
                            ]
                        },
                        'phone': '+14045814000',
                        'display_phone': '(404) 581-4000',
                        'distance': '5911.261033815513'
                    },
                    {
                        'id': 'ERoYrBHNmTEEChY3RGaOGQ',
                        'alias': 'egg-harbor-café-atlanta-3',
                        'name': 'Egg Harbor Café',
                        'image_url': 'https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '783',
                        'categories': [
                            {
                                'alias': 'breakfast_brunch',
                                'title': 'Breakfast & Brunch'
                            },
                            {
                                'alias': 'gluten_free',
                                'title': 'Gluten-Free'
                            },
                            {
                                'alias': 'sandwiches',
                                'title': 'Sandwiches'
                            }
                        ],
                        'rating': '4.5',
                        'coordinates': {
                            'latitude': '33.8051032144595',
                            'longitude': '-84.3941098822784'
                        },
                        'transactions': [
                            'delivery'
                        ],
                        'price' : '$$$',
                        'location': {
                            'address1': '1820 Peachtree Road NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30309',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '1820 Peachtree Road NW',
                               'Atlanta, GA 30309'
                            ]
                        },
                        'phone': '+14702251901',
                        'display_phone': '(470) 225-1901',
                        'distance': '2096.338243923308'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray) firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual(
                "Restaurant (name: Sublime Doughnuts price: $ location: 535 10th St NW, Atlanta, GA 30318 hours:  distance: 4569.2202838849535 review score: 4 review count: 1167 menu URL: https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg id: iG8DnZCnKHH_KYC8pG14NQ)\n" +
                "Restaurant (name: Georgia Aquarium price: $$ location: 225 Baker St, Atlanta, GA 30313 hours:  distance: 5911.261033815513 review score: 4 review count: 2684 menu URL: https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg id: W2uLX3tc3YrhKKxEIPRmAw)\n" +
                "Restaurant (name: Egg Harbor Café price: $$$ location: 1820 Peachtree Road NW, Atlanta, GA 30309 hours:  distance: 2096.338243923308 review score: 4.5 review count: 783 menu URL: https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg id: ERoYrBHNmTEEChY3RGaOGQ)\n",
                thePopulatedManager.ToString());
        }

        [TestMethod]
        public void ShouldNotPopulateForOneRestaurantDataOneInvalid() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                            ],
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray) firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual("", thePopulatedManager.ToString());
        }

        [TestMethod]
        public void ShouldPopulateForManyValidRestaurantDataFirstInvalid() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                         ],
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }, 
                    {
                        'id': 'W2uLX3tc3YrhKKxEIPRmAw',
                        'alias': 'georgia-aquarium-atlanta',
                        'name': 'Georgia Aquarium',
                        'image_url': 'https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '2684',
                        'categories': [
                            {
                                'alias': 'aquariums',
                                'title': 'Aquariums'
                            }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.7630463019815',
                            'longitude': '-84.3947916838531'
                        },
                        'transactions': [],
                        'price': '$$',
                        'location': {
                            'address1': '225 Baker St',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30313',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '225 Baker St',
                               'Atlanta, GA 30313'
                            ]
                        },
                        'phone': '+14045814000',
                        'display_phone': '(404) 581-4000',
                        'distance': '5911.261033815513'
                    },
                    {
                        'id': 'ERoYrBHNmTEEChY3RGaOGQ',
                        'alias': 'egg-harbor-café-atlanta-3',
                        'name': 'Egg Harbor Café',
                        'image_url': 'https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '783',
                        'categories': [
                            {
                                'alias': 'breakfast_brunch',
                                'title': 'Breakfast & Brunch'
                            },
                            {
                                'alias': 'gluten_free',
                                'title': 'Gluten-Free'
                            },
                            {
                                'alias': 'sandwiches',
                                'title': 'Sandwiches'
                            }
                        ],
                        'rating': '4.5',
                        'coordinates': {
                            'latitude': '33.8051032144595',
                            'longitude': '-84.3941098822784'
                        },
                        'transactions': [
                            'delivery'
                        ],
                        'price' : '$$$',
                        'location': {
                            'address1': '1820 Peachtree Road NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30309',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '1820 Peachtree Road NW',
                               'Atlanta, GA 30309'
                            ]
                        },
                        'phone': '+14702251901',
                        'display_phone': '(470) 225-1901',
                        'distance': '2096.338243923308'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray)firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual(
                "Restaurant (name: Georgia Aquarium price: $$ location: 225 Baker St, Atlanta, GA 30313 hours:  distance: 5911.261033815513 review score: 4 review count: 2684 menu URL: https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg id: W2uLX3tc3YrhKKxEIPRmAw)\n" +
                "Restaurant (name: Egg Harbor Café price: $$$ location: 1820 Peachtree Road NW, Atlanta, GA 30309 hours:  distance: 2096.338243923308 review score: 4.5 review count: 783 menu URL: https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg id: ERoYrBHNmTEEChY3RGaOGQ)\n",
                thePopulatedManager.ToString());
        }

        [TestMethod]
        public void ShouldPopulateForManyValidRestaurantDataMiddleInvalid() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                         ],
                        'price': '$',
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }, 
                    {
                        'id': 'W2uLX3tc3YrhKKxEIPRmAw',
                        'alias': 'georgia-aquarium-atlanta',
                        'name': 'Georgia Aquarium',
                        'image_url': 'https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '2684',
                        'categories': [
                            {
                                'alias': 'aquariums',
                                'title': 'Aquariums'
                            }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.7630463019815',
                            'longitude': '-84.3947916838531'
                        },
                        'transactions': [],
                        'location': {
                            'address1': '225 Baker St',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30313',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '225 Baker St',
                               'Atlanta, GA 30313'
                            ]
                        },
                        'phone': '+14045814000',
                        'display_phone': '(404) 581-4000',
                        'distance': '5911.261033815513'
                    },
                    {
                        'id': 'ERoYrBHNmTEEChY3RGaOGQ',
                        'alias': 'egg-harbor-café-atlanta-3',
                        'name': 'Egg Harbor Café',
                        'image_url': 'https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '783',
                        'categories': [
                            {
                                'alias': 'breakfast_brunch',
                                'title': 'Breakfast & Brunch'
                            },
                            {
                                'alias': 'gluten_free',
                                'title': 'Gluten-Free'
                            },
                            {
                                'alias': 'sandwiches',
                                'title': 'Sandwiches'
                            }
                        ],
                        'rating': '4.5',
                        'coordinates': {
                            'latitude': '33.8051032144595',
                            'longitude': '-84.3941098822784'
                        },
                        'transactions': [
                            'delivery'
                        ],
                        'price' : '$$$',
                        'location': {
                            'address1': '1820 Peachtree Road NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30309',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '1820 Peachtree Road NW',
                               'Atlanta, GA 30309'
                            ]
                        },
                        'phone': '+14702251901',
                        'display_phone': '(470) 225-1901',
                        'distance': '2096.338243923308'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray)firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual(
                "Restaurant (name: Sublime Doughnuts price: $ location: 535 10th St NW, Atlanta, GA 30318 hours:  distance: 4569.2202838849535 review score: 4 review count: 1167 menu URL: https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg id: iG8DnZCnKHH_KYC8pG14NQ)\n" +
                "Restaurant (name: Egg Harbor Café price: $$$ location: 1820 Peachtree Road NW, Atlanta, GA 30309 hours:  distance: 2096.338243923308 review score: 4.5 review count: 783 menu URL: https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg id: ERoYrBHNmTEEChY3RGaOGQ)\n",
                thePopulatedManager.ToString());
        }

        [TestMethod]
        public void ShouldPopulateForManyValidRestaurantDataLastInvalid() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                         ],
                        'price': '$',
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }, 
                    {
                        'id': 'W2uLX3tc3YrhKKxEIPRmAw',
                        'alias': 'georgia-aquarium-atlanta',
                        'name': 'Georgia Aquarium',
                        'image_url': 'https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '2684',
                        'categories': [
                            {
                                'alias': 'aquariums',
                                'title': 'Aquariums'
                            }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.7630463019815',
                            'longitude': '-84.3947916838531'
                        },
                        'transactions': [],
                        'price': '$$',
                        'location': {
                            'address1': '225 Baker St',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30313',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '225 Baker St',
                               'Atlanta, GA 30313'
                            ]
                        },
                        'phone': '+14045814000',
                        'display_phone': '(404) 581-4000',
                        'distance': '5911.261033815513'
                    },
                    {
                        'id': 'ERoYrBHNmTEEChY3RGaOGQ',
                        'alias': 'egg-harbor-café-atlanta-3',
                        'name': 'Egg Harbor Café',
                        'image_url': 'https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '783',
                        'categories': [
                            {
                                'alias': 'breakfast_brunch',
                                'title': 'Breakfast & Brunch'
                            },
                            {
                                'alias': 'gluten_free',
                                'title': 'Gluten-Free'
                            },
                            {
                                'alias': 'sandwiches',
                                'title': 'Sandwiches'
                            }
                        ],
                        'rating': '4.5',
                        'coordinates': {
                            'latitude': '33.8051032144595',
                            'longitude': '-84.3941098822784'
                        },
                        'transactions': [
                            'delivery'
                        ],
                        'location': {
                            'address1': '1820 Peachtree Road NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30309',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '1820 Peachtree Road NW',
                               'Atlanta, GA 30309'
                            ]
                        },
                        'phone': '+14702251901',
                        'display_phone': '(470) 225-1901',
                        'distance': '2096.338243923308'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray)firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual(
                "Restaurant (name: Sublime Doughnuts price: $ location: 535 10th St NW, Atlanta, GA 30318 hours:  distance: 4569.2202838849535 review score: 4 review count: 1167 menu URL: https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg id: iG8DnZCnKHH_KYC8pG14NQ)\n" +
                "Restaurant (name: Georgia Aquarium price: $$ location: 225 Baker St, Atlanta, GA 30313 hours:  distance: 5911.261033815513 review score: 4 review count: 2684 menu URL: https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw image URL: https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg id: W2uLX3tc3YrhKKxEIPRmAw)\n",
                thePopulatedManager.ToString());
        }

        [TestMethod]
        public void ShouldNotPopulateForManyRestaurantDataAllInvalid() {
            string json = @"{
                'businesses' : [
                    {
                        'id': 'iG8DnZCnKHH_KYC8pG14NQ',
                        'alias': 'sublime-doughnuts-atlanta',
                        'name': 'Sublime Doughnuts',
                        'image_url': 'https://s3-media1.fl.yelpcdn.com/bphoto/O2oo77Iu6Q3EsN0E7g184w/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/sublime-doughnuts-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '1167',
                        'categories': [
                        {
                            'alias': 'donuts',
                            'title': 'Donuts'
                        },
                        {
                            'alias': 'burgers',
                            'title': 'Burgers'
                        }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.78154',
                            'longitude': '-84.40513'
                        },
                        'transactions': [
                        'pickup',
                        'delivery'
                         ],
                        'location': {
                            'address1': '535 10th St NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30318',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                            '535 10th St NW',
                            'Atlanta, GA 30318'
                                ]
                        },
                        'phone': '+14048971801',
                        'display_phone': '(404) 897-1801',
                        'distance': '4569.2202838849535'
                    }, 
                    {
                        'id': 'W2uLX3tc3YrhKKxEIPRmAw',
                        'alias': 'georgia-aquarium-atlanta',
                        'name': 'Georgia Aquarium',
                        'image_url': 'https://s3-media4.fl.yelpcdn.com/bphoto/gk6BdrATSGVv6Rk2Yjzscg/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/georgia-aquarium-atlanta?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '2684',
                        'categories': [
                            {
                                'alias': 'aquariums',
                                'title': 'Aquariums'
                            }
                        ],
                        'rating': '4.0',
                        'coordinates': {
                            'latitude': '33.7630463019815',
                            'longitude': '-84.3947916838531'
                        },
                        'transactions': [],
                        'location': {
                            'address1': '225 Baker St',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30313',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '225 Baker St',
                               'Atlanta, GA 30313'
                            ]
                        },
                        'phone': '+14045814000',
                        'display_phone': '(404) 581-4000',
                        'distance': '5911.261033815513'
                    },
                    {
                        'id': 'ERoYrBHNmTEEChY3RGaOGQ',
                        'alias': 'egg-harbor-café-atlanta-3',
                        'name': 'Egg Harbor Café',
                        'image_url': 'https://s3-media2.fl.yelpcdn.com/bphoto/tCSCB3NnK6lBdSesFr1eXA/o.jpg',
                        'is_closed': 'false',
                        'url': 'https://www.yelp.com/biz/egg-harbor-caf%C3%A9-atlanta-3?adjust_creative=I7CeCNvUlMowfnqP0AdBMw&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=I7CeCNvUlMowfnqP0AdBMw',
                        'review_count': '783',
                        'categories': [
                            {
                                'alias': 'breakfast_brunch',
                                'title': 'Breakfast & Brunch'
                            },
                            {
                                'alias': 'gluten_free',
                                'title': 'Gluten-Free'
                            },
                            {
                                'alias': 'sandwiches',
                                'title': 'Sandwiches'
                            }
                        ],
                        'rating': '4.5',
                        'coordinates': {
                            'latitude': '33.8051032144595',
                            'longitude': '-84.3941098822784'
                        },
                        'transactions': [
                            'delivery'
                        ],
                        'location': {
                            'address1': '1820 Peachtree Road NW',
                            'address2': '',
                            'address3': '',
                            'city': 'Atlanta',
                            'zip_code': '30309',
                            'country': 'US',
                            'state': 'GA',
                            'display_address': [
                               '1820 Peachtree Road NW',
                               'Atlanta, GA 30309'
                            ]
                        },
                        'phone': '+14702251901',
                        'display_phone': '(470) 225-1901',
                        'distance': '2096.338243923308'
                    }
                ]
            }";

            JObject firstRestaurant = JObject.Parse(json);
            JArray restaurants = (JArray)firstRestaurant.GetValue("businesses");

            var query = new RestaurantsQuery(new RestaurantFilters(), new RestaurantManager());

            RestaurantManager thePopulatedManager = query.PopulateRestaurants(restaurants);

            Assert.AreEqual(
                "",
                thePopulatedManager.ToString());
        }
    }
}
