using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.PresentationLayer.DTOs
{
    public class UserDto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}