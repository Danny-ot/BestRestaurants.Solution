namespace BestRestaurants.Models
{
    public class Review
    {
        public int ReviewId{get; set;}

        public string ReviewDescription{get; set;}

        public int RestaurantId{get; set;}

        public virtual Restaurant Restaurant{get; set;}
    }
}