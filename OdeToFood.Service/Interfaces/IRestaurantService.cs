using OdeToFood.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Service.Interfaces
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant Get(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        string MessageOfTheDay();

        Restaurant UpdateRestaurant(Restaurant restaurant);
    }
}
