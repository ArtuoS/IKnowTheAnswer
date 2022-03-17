using IKnowTheAnswer.Core.DTOs;

namespace IKnowTheAnswer.Core.Interfaces.Services
{
    public interface IQuestionLogger
    {
        void Log(QuestionLoggerDto questionLoggerDto);
    }
}