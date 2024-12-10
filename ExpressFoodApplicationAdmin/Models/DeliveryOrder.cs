namespace ExpressFoodApplicationAdmin.Models
{
    public class DeliveryOrder : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<FoodItemInOrder>? FoodItemsInOrder { get; set; }
    }
}
