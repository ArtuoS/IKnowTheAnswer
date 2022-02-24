namespace IKnowTheAnswer.Core.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string toCheck) : base($"Can't login, please check your {toCheck}.")
        { }
    }
}