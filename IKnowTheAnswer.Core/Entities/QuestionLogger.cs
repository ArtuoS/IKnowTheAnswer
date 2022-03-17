using IKnowTheAnswer.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKnowTheAnswer.Core.Entities
{
    public class QuestionLogger
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public Question Question { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public EQuestionLogType QuestionType { get; set; }
    }
}