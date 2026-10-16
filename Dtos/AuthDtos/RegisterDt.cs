using System.ComponentModel.DataAnnotations;

namespace E_CommerceMangementSystem.Dtos.AuthDtos
{
    public class RegisterDto
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, RegularExpression("^(Admin|Customer)$")]
        public string Role { get; set; }
    }
}
