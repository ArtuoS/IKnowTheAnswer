using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Core.DTOs.User
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
    }
}