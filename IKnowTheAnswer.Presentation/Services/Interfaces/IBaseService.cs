using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.Entities;

namespace IKnowTheAnswer.Presentation.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsyc<T>(ApiRequest apiRequest);
    }
}