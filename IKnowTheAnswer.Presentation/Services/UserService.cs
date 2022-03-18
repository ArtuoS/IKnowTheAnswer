using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.Entities;
using IKnowTheAnswer.Presentation.Services.Interfaces;

namespace IKnowTheAnswer.Presentation.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _httpClient;
        public UserService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDto> DeleteAsync(int id)
        {
            return await SendAsyc<object>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, $"/api/user/{id}")
            });
        }

        public async Task<ResponseDto> GetAll()
        {
            return await SendAsyc<IList<UserGetDto>>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/user/")
            });
        }

        public async Task<ResponseDto> GetById(int id)
        {
            return await SendAsyc<UserGetDto>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, $"/api/user/{id}")
            });
        }

        public async Task<ResponseDto> Insert(UserInsertDto userInsertDto)
        {
            return await SendAsyc<object>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/user/"),
                Data = userInsertDto
            });
        }

        public async Task<ResponseDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            return await SendAsyc<object>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/user/"),
                Data = userUpdateDto
            });
        }
    }
}