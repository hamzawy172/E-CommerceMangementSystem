using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMangementSystem.Models
{
    [Index(nameof(Name) , IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        [Required , MinLength(2) , MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string ?Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
