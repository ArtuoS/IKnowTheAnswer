using IKnowTheAnswer.PresentationLayer.Entities;
using IKnowTheAnswer.PresentationLayer.Enums;

namespace IKnowTheAnswer.PresentationLayer.DTOs
{
    public class QuestionLoggerDto
    {
        public QuestionLoggerDto(User user, Question question, EQuestionLogType questionType)
        {
            User = user;
            Question = question;
            QuestionType = questionType;
        }

        public int Id { get; set; }
        public User User { get; set; }
        public Question Question { get; set; }
        public EQuestionLogType QuestionType { get; set; }
    }
}