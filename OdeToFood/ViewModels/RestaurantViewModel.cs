using OdeToFood.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    public class RestaurantViewModel
    {
        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Please enter name of restaurant"), MaxLength(80)]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
