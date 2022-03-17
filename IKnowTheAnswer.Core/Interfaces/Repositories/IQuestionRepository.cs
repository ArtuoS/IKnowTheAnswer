using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.DTOs.Question;

namespace IKnowTheAnswer.Core.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<ResponseDto> Insert(QuestionInsertDto questionDto);

        Task<ResponseDto> Update(int id, QuestionUpdateDto questionDto);

        Task<ResponseDto> Delete(int id);

        Task<ResponseDto> Get(int id);

        Task<ResponseDto> GetAll();
    }
}