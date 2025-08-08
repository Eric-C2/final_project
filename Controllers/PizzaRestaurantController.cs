using Microsoft.AspNetCore.Mvc;
using final_project.Models;
using final_project.Data;
using final_project.Controllers;
using System.Runtime.InteropServices;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaRestaurantController : ControllerBase
    {
        private readonly ILogger<PizzaRestaurantController> _logger;
        private readonly PizzaRestaurantDAO _context;
        public PizzaRestaurantController(ILogger<PizzaRestaurantController> logger, PizzaRestaurantDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(PizzaRestaurant pizzaRestaurant)
        {
            _context.Add(pizzaRestaurant);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            _context.Get(id);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _context.Delete(id);
            return Ok();
        }

        //[HttpPut]
        //public IActionResult Put(PizzaRestaurant pizzaRestaurant)
        //{
            
        //}

    }
}
