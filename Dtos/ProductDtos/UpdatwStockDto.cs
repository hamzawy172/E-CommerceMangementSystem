using System.ComponentModel.DataAnnotations;

namespace E_CommerceMangementSystem.Dtos.ProductDtos
{
    public class UpdatwStockDto
    {
        [Required, Range(1, 1000000)]
        public int Quantity { get; set; }
    }
}
