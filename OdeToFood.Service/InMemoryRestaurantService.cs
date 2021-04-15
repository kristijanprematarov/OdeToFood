using OdeToFood.Entities;
using OdeToFood.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Service
{
    public class InMemoryRestaurantService /*: IRestaurantService*/
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantService()
        {
            _restaurants = new List<Restaurant>
            { 
                new Restaurant { Id = 1, Name = "KPR Snacks"},
                new Restaurant { Id = 2, Name = "KPR Pizzas"},
                new Restaurant { Id = 3, Name = "KPR Protein"}
            };
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);

            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurants.AsEnumerable();
        }



    }
}
