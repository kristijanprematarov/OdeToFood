using OdeToFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    public class HomeIndexViewModel // home controller index view
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public string CurrentMessage { get; set; }
    }
}
