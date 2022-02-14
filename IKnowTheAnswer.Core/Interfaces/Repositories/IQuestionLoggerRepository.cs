using IKnowTheAnswer.Core.DTOs;

namespace IKnowTheAnswer.Core.Interfaces.Repositories
{
    public interface IQuestionLoggerRepository
    {
        void Log(QuestionLoggerDto questionLoggerDto);
    }
}
