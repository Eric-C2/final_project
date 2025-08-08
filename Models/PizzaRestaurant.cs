namespace final_project.Models
{
    public class PizzaRestaurant
    {
        public int Id { get; set; }//ID isn't allowed to be null, the user cannot set the ID, it will break
        public required string Name { get; set; }//the name must not be null
        public bool? HasStuffedCrust { get; set; }
        public int? YearFounded { get; set; }
        public bool? IsOverPriced { get; set; }//thought about forcing this to not be null, since I'm salty abt pizza prices rn
        //20$ for a 14-inch pizza???? Insane.
    }
}
