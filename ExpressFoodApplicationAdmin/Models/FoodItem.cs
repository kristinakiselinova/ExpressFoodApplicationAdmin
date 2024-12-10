namespace ExpressFoodApplicationAdmin.Models
{
    public class FoodItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string FoodItemImage { get; set; }
        public Guid? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public ICollection<FoodItemInOrder>? FoodItemInOrders { get; set; }
    }
}
