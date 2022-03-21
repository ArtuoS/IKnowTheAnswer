using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Core.DTOs.User
{
    public class UserInsertDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}