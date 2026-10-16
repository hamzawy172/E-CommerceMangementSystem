using System.ComponentModel.DataAnnotations;

namespace E_CommerceMangementSystem.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        [Required, MaxLength(100), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required, Range(0.01, 1000000)]
        public decimal Price { get; set; }
        [Required, Range(1, 1000000)]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

    }
}
