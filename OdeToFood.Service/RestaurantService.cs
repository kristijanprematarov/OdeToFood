using OdeToFood.Entities;
using OdeToFood.Repository.Interfaces;
using OdeToFood.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            var addedRestaurant = _restaurantRepository.AddRestaurant(restaurant);

            return addedRestaurant;
        }

        public Restaurant Get(int id)
        {
            var restaurant = _restaurantRepository.Get(id);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            var restaurants = _restaurantRepository.GetAllRestaurants();
            return restaurants;
        }

        public string MessageOfTheDay()
        {
            return "Have an awesome day";
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.UpdateRestaurant(restaurant);
            return restaurant;
        }
    }
}
