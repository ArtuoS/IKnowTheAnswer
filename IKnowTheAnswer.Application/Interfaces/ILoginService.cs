using IKnowTheAnswer.Application.DTOs;
using IKnowTheAnswer.Core.DTOs;

namespace IKnowTheAnswer.Application.Interfaces;

public interface ILoginService
{
    Task<ResponseDto> SignIn(SignInDto signInDto);

    void ValidateCanSignIn(SignInDto signInDto);
}