using IKnowTheAnswer.PresentationLayer.DTOs;
using IKnowTheAnswer.PresentationLayer.Entities;

namespace IKnowTheAnswer.PresentationLayer.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsyc(ApiRequest apiRequest);
    }
}