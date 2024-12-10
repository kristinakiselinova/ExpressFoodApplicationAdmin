using System.ComponentModel.DataAnnotations;

namespace ExpressFoodApplicationAdmin.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
