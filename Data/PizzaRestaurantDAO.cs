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

        public bool? Add(PizzaRestaurant pizzaRestaurant)
        {
            if(pizzaRestaurant == null)
            {
                return null;
            }
            else
            {
                try
                {
                    _context.PizzaRestaurants.Add(pizzaRestaurant);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            }
        }
        public PizzaRestaurant? Get(int id)
        {
            var entryToReturn = _context.PizzaRestaurants//return data
                .Where(//where the entry in our db has an ID that matches the input
                entry => entry.Id.Equals(id))
                .FirstOrDefault();//get the first one that matches

            if(entryToReturn == null)
            {//if no entry is found
                return null;//return null
            }
            else
            {//otherwise send the entry
                return entryToReturn;
            }
        }
        public PizzaRestaurant? GetByName(string name)
        {
            try
            {
                var entryToReturn = _context.PizzaRestaurants.Where(entry => entry.Name.Equals(name)).FirstOrDefault();
                return entryToReturn;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        //public int? Update()
        public bool? Delete(int id)
        {
            var entryToDelete = Get(id);

            if (entryToDelete != null)
            {
                try
                {
                    _context.PizzaRestaurants.Remove(entryToDelete);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            }
            else
            {
                return false;//thought about making it try again, but I figured that would be bad practice
            }
        }

        public bool? Put(PizzaRestaurant pizzaRestaurant)//there's gotta be a way to make this a non-specific object, so you can toss in anything
        {
            var entryToUpdate = Get(pizzaRestaurant.Id);
            try
            {
                if(entryToUpdate != null)
                {
                    entryToUpdate.Name = pizzaRestaurant.Name;
                    entryToUpdate.HasStuffedCrust = pizzaRestaurant.HasStuffedCrust;
                    entryToUpdate.YearFounded = pizzaRestaurant.YearFounded;
                    entryToUpdate.IsOverPriced = pizzaRestaurant.IsOverPriced;
                    _context.PizzaRestaurants.Update(entryToUpdate);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
