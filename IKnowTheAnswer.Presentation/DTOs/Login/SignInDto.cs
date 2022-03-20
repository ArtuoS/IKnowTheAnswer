using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Presentation.DTOs.Login
{
    public class SignInDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
