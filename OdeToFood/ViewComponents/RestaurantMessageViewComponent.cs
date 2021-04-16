using Microsoft.AspNetCore.Mvc;
using OdeToFood.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantMessageViewComponent : ViewComponent
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantMessageViewComponent(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _restaurantService.MessageOfTheDay();

            return View("Default", model);
        }
    }
}
