namespace ExpressFoodApplicationAdmin.Models
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string OpeningHours { get; set; }
        public string RestaurantImage { get; set; }
        public float? Rating { get; set; }
        public ICollection<FoodItem>? FoodItems { get; set; }
    }
}
