namespace IKnowTheAnswer.Presentation.Entities
{
    public static class SD
    {
        public static string IKnowTheAnswerApi { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}