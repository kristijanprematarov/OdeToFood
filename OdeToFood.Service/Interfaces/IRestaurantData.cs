using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Service.Interfaces
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}
