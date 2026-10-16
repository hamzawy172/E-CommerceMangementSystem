using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMangementSystem.Models
{
    [Index(nameof(Email) , IsUnique =true)]
    public class User
    {
        public int Id { get; set; }
        [Required , MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required ]
        public string Password { get; set; }
        [Required , RegularExpression("^(Admin|Customer)$")]
        public string Role { get; set; }

        public ICollection<Order> orders { get; set; } = new List<Order>();
    }
}
