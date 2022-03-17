using IKnowTheAnswer.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Core.DTOs.Question
{
    public class QuestionInsertDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Answer { get; set; }

        public IList<Picture> Pictures { get; set; }
        public int UserId { get; set; }
    }
}