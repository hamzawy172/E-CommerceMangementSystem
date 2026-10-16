using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.Dtos.OrderDto
{
    public class CreateOrderDto
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required, RegularExpression("^(Pending|Completed|Cancelled)$")]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        public int UserId { get; set; }


    }
}
