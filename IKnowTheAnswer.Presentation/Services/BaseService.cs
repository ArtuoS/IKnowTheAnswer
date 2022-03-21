using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.Entities;
using IKnowTheAnswer.Presentation.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using static IKnowTheAnswer.Presentation.Entities.SD;

namespace IKnowTheAnswer.Presentation.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseDto> SendAsyc<T>(ApiRequest apiRequest)
        {
            var response = new ResponseDto();

            try
            {
                var client = httpClient.CreateClient();
                client.DefaultRequestHeaders.Clear();

                var message = new HttpRequestMessage()
                {
                    RequestUri = new Uri(apiRequest.Url),
                };

                message.Headers.Add("Accept", "application/json");

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                                                        Encoding.UTF8,
                                                        "application/json");
                }

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

                var apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(apiContent))
                {
                    response.Data = JsonConvert.DeserializeObject<T>(apiContent);
                }

                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = new List<string> { Convert.ToString(ex.Message) }.ToString();

                return response;
            }
        }
    }
}