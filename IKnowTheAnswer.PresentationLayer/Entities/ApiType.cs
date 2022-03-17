namespace IKnowTheAnswer.PresentationLayer.Entities
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