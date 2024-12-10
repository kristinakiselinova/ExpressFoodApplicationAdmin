using Microsoft.AspNetCore.Identity;

namespace ExpressFoodApplicationAdmin.Models
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<DeliveryOrder>? Orders { get; set; }
    }
}
