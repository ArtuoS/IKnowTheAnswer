using IKnowTheAnswer.Core.Enums;

namespace IKnowTheAnswer.Core.DTOs
{
    public class QuestionLoggerDto
    {
        public QuestionLoggerDto(Entities.User user, Entities.Question question, EQuestionLogType questionType)
        {
            User = user;
            Question = question;
            QuestionType = questionType;
        }

        public int Id { get; set; }
        public Entities.User User { get; set; }
        public Entities.Question Question { get; set; }
        public EQuestionLogType QuestionType { get; set; }
    }
}