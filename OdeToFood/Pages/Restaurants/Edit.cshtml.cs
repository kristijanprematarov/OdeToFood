using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Entities;
using OdeToFood.Service.Interfaces;

namespace OdeToFood.Pages.Restaurants
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRestaurantService _restaurantService;

        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = _restaurantService.Get(id);
            if (Restaurant == null)
            {
                RedirectToAction("Index", "Home");
            }

            return Page();
        }

        public IActionResult OnPost(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _restaurantService.UpdateRestaurant(restaurant);
                return RedirectToAction("Details", "Home", new { id = restaurant.Id });
            }
            return Page();
        }
    }
}
