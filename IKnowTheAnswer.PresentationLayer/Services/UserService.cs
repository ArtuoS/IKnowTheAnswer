using IKnowTheAnswer.PresentationLayer.DTOs;
using IKnowTheAnswer.PresentationLayer.Entities;
using IKnowTheAnswer.PresentationLayer.Services.Interfaces;

namespace IKnowTheAnswer.PresentationLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        public async Task<ResponseDto> DeleteProductAsync(int id)
        {
            return await SendAsyc(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, $"/api/users/{id}")
            });
        }

        public async Task<ResponseDto> GetAll()
        {
            return await SendAsyc(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/users/")
            });
        }

        public async Task<ResponseDto> GetById(int id)
        {
            return await SendAsyc(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, $"/api/users/{id}")
            });
        }

        public async Task<ResponseDto> Insert(UserInsertDto userInsertDto)
        {
            return await SendAsyc(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/users/"),
                Data = userInsertDto
            });
        }

        public async Task<ResponseDto> UpdateProductAsync(UserUpdateDto userUpdateDto)
        {
            return await SendAsyc(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = string.Concat(SD.IKnowTheAnswerApi, "/api/users/"),
                Data = userUpdateDto
            });
        }
    }
}