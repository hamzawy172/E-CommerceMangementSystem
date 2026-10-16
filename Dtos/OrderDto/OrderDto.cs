using System.ComponentModel.DataAnnotations;

namespace E_CommerceMangementSystem.Dtos.OrderDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required, RegularExpression("^(Pending|Completed|Cancelled)$")]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        public int UserId { get; set; }
    }
}
