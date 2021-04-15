using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Entities;
using OdeToFood.Models;
using OdeToFood.Service.Interfaces;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{     
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantService _restaurantService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();

            model.Restaurants = _restaurantService.GetAllRestaurants();
            model.CurrentMessage = "Have a nice and delicious day";

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //
        public IActionResult Create(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };

                newRestaurant = _restaurantService.AddRestaurant(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Details(int id)
        {
            var restaurant = _restaurantService.Get(id);

            if (restaurant == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
