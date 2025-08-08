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
            {//this means that whatever called this method sent something null
                return null;//It doesn't mean that the entry already exists
            }
            else
            {
                /*
                 * before the try catch block would be the logic to check if the entry already exists,
                 * but I'm unsure of how to check for an existing entry, since all of the fields might be null.
                 * For now I guess it will be the name
                 *
                 */

                var duplicateEntry = GetByName(pizzaRestaurant.Name);
                if(duplicateEntry != null)
                {
                    return null;//this means the entry exists already
                }

                try
                {
                    _context.PizzaRestaurants.Add(pizzaRestaurant);
                    _context.SaveChanges();
                    return true;//we added the entry successfully!
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;//something broke
                }
            }
        }
        public PizzaRestaurant? Get(int id)
        {
            try
            {
                var entryToReturn = _context.PizzaRestaurants//return data
                    .Where(//where the entry in our db has an ID that matches the input
                    entry => entry.Id.Equals(id))
                    .FirstOrDefault();//get the first one that matches

                if (entryToReturn == null)
                {//if no entry is found
                    return null;//return null
                }
                else
                {//otherwise send the entry
                    return entryToReturn;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return null;//something broke
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
                return null;//something broke
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
                return null;//thought about making it try again, but I figured that would be bad practice
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
                else
                {
                    return null;
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
