using System.ComponentModel.DataAnnotations;

namespace E_CommerceMangementSystem.Dtos.OrderDto
{
    public class PatchStatusDto
    {
        [Required, RegularExpression("^(Pending|Completed|Cancelled)$")]
        public string Status { get; set; }
    }
}
