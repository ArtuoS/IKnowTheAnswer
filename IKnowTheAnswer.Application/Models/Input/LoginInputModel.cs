namespace IKnowTheAnswer.Application.Models.Input
{
    public class LoginInputModel
    {
        public LoginInputModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}