using IKnowTheAnswer.Core.Entities;

namespace IKnowTheAnswer.Core.DTOs.Question
{
    public class QuestionInsertDto
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public IList<Picture> Pictures { get; set; }
        public int UserId { get; set; }
    }
}