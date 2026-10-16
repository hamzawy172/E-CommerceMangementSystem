using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceMangementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required , MaxLength(100) , MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string ?Description { get; set; }
        [Required , Range(0.01 , 1000000)]
        public decimal Price { get; set; }
        [Required, Range(1, 1000000)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
