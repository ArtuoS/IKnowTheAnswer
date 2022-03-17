using IKnowTheAnswer.Application.Models.Input;
using IKnowTheAnswer.Core.DTOs;

namespace IKnowTheAnswer.Application.Interfaces;

public interface ILoginService
{
    Task<ResponseDto> Login(LoginInputModel loginInputModel);

    void ValidateCanLogin(LoginInputModel loginInputModel);
}