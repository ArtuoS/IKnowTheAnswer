using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.DTOs.Login;

namespace IKnowTheAnswer.Presentation.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseDto> SignIn(SignInDto signInDto);
    }
}