using IKnowTheAnswer.PresentationLayer.DTOs;
using IKnowTheAnswer.PresentationLayer.Entities;
using IKnowTheAnswer.PresentationLayer.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using static IKnowTheAnswer.PresentationLayer.Entities.SD;

namespace IKnowTheAnswer.PresentationLayer.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseDto> SendAsyc(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                                                        Encoding.UTF8,
                                                        "application/json");
                }

                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;

                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto
                {
                    Message = new List<string> { Convert.ToString(ex.Message) }.ToString(),
                    Success = false
                };

                var response = JsonConvert.SerializeObject(responseDto);
                var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(response);
                return apiResponseDto;
            }
        }
    }
}