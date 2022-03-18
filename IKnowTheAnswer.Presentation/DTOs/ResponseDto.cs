namespace IKnowTheAnswer.Presentation.DTOs
{
    public class ResponseDto
    {
        public string? Message { get; set; }
        public object? Data { get; set; }
        public bool Success { get; set; } = false;
    }
}