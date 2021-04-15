using OdeToFood.Data;
using OdeToFood.Entities;
using OdeToFood.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DataContext _context;

        public RestaurantRepository(DataContext context)
        {
            _context = context;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            var restaurants = _context.Restaurants.AsEnumerable();

            return restaurants;
        }
    }
}
