namespace IKnowTheAnswer.Core.Entities
{
    public class Globals
    {
        private static User LoggedUser;

        public static void SetLoggedUser(User user)
            => LoggedUser = user;

        public static User GetLoggedUser()
            => LoggedUser;
    }
}