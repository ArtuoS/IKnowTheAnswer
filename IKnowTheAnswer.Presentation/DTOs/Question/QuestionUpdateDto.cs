using IKnowTheAnswer.Presentation.Entities;
using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Presentation.DTOs
{
    public class QuestionUpdateDto
    {
        [MaxLength(150)]
        public string Title { get; set; }

        public string Answer { get; set; }
        public IList<Picture> Pictures { get; set; }
        public int UserId { get; set; }
    }
}