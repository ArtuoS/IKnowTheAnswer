using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Presentation.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}