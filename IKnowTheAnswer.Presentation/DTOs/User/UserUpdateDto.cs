using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Presentation.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}