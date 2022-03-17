using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.PresentationLayer.DTOs
{
    public class UserInsertDto
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}