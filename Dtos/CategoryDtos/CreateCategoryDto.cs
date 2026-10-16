using System.ComponentModel.DataAnnotations;

namespace E_CommerceMangementSystem.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
