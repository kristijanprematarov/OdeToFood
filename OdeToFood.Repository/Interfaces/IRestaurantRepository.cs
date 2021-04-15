using OdeToFood.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Repository.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant Get(int id);

        Restaurant AddRestaurant(Restaurant restaurant);
    }
}
