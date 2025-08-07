using Microsoft.AspNetCore.Mvc;
using final_project.Models;
using final_project.Data;
using final_project.Controllers;
using System.Runtime.InteropServices;

namespace final_project.Controllers
{
    public class PizzaRestaurantController : ControllerBase
    {
        private readonly ILogger<PizzaRestaurantController> _logger;
        private readonly TeamMemberContext _context;
        public PizzaRestaurantController(ILogger<PizzaRestaurantController> logger, TeamMemberContext context)
        {
            _logger = logger;
            _context = context;
        }

        //[HttpPost]
        public IActionResult Post(PizzaRestaurant pizzaRestaurant)
        {
            _context.Add(pizzaRestaurant);
        }

        //[HttpPut]
        //public IActionResult Put(PizzaRestaurant pizzaRestaurant)
        //{
            
        //}

    }
}
