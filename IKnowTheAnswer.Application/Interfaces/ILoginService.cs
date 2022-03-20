using IKnowTheAnswer.Application.Models.Input;
using IKnowTheAnswer.Core.DTOs;

namespace IKnowTheAnswer.Application.Interfaces;

public interface ILoginService
{
    Task<ResponseDto> SignIn(SignInInputModel signInInputModel);

    void ValidateCanLogin(SignInInputModel signInInputModel);
}