using static IKnowTheAnswer.Presentation.Entities.SD;

namespace IKnowTheAnswer.Presentation.Entities
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}