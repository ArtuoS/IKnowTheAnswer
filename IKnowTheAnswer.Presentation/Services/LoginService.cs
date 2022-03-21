using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.DTOs.Login;
using IKnowTheAnswer.Presentation.Entities;
using IKnowTheAnswer.Presentation.Services.Interfaces;

namespace IKnowTheAnswer.Presentation.Services
{
    public class LoginService : BaseService, ILoginService
    {
        private readonly IHttpClientFactory _httpClient;
        public LoginService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto> SignIn(SignInDto signInDto)
        {
            return await SendAsyc<UserGetDto>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/login/signin"),
                Data = signInDto
            });
        }
    }
}
