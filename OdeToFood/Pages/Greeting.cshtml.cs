using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Service.Interfaces;

namespace OdeToFood.Pages
{
    public class GreetingModel : PageModel
    {
        private readonly IRestaurantService _restaurantService;

        public string CurrentGreeting { get; set; }
        public GreetingModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public void OnGet(string name)
        {
            CurrentGreeting = $"{name} : {_restaurantService.MessageOfTheDay()}";
        }
    }
}
