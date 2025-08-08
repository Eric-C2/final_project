using final_project.Models;
using System.Diagnostics;

namespace final_project.Data
{
    public class PizzaRestaurantDAO
    {
        private readonly TeamMemberContext _context;
        public PizzaRestaurantDAO(TeamMemberContext context)
        {
        
            _context = context;
        }

        public int? Add(PizzaRestaurant pizzaRestaurant)
        {
            //var restaurants = _context.PizzaRestaurants.Where(entry => entry.Id)

            try
            {
                _context.PizzaRestaurants.Add(pizzaRestaurant);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 0;
            }
        }
    }
}
