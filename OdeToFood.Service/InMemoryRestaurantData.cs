using OdeToFood.Models;
using OdeToFood.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Service
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            { 
                new Restaurant { Id = 1, Name = "KPR Snacks"},
                new Restaurant { Id = 2, Name = "KPR Pizzas"},
                new Restaurant { Id = 3, Name = "KPR Protein"}
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurants.AsEnumerable();
        }
    }
}
