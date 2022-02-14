using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKnowTheAnswer.Core.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Answer { get; set; }
        public IList<Picture> Pictures { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
