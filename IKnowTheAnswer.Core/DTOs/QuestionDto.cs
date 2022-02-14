using IKnowTheAnswer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Core.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public IList<byte[]> Pictures { get; set; }
        public User User { get; set; }
    }
}
