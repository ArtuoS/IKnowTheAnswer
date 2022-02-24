using IKnowTheAnswer.Core.DTOs;

namespace IKnowTheAnswer.Core.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<ResponseDto<QuestionDto>> Insert(QuestionDto questionDto);
        Task<ResponseDto<QuestionDto>> Update(QuestionDto questionDto);
        Task<ResponseDto<QuestionDto>> Delete(int id);
        Task<ResponseDto<QuestionDto>> Get(int id);
        Task<ResponseDto<IList<QuestionDto>>> GetAll();
    }
}
