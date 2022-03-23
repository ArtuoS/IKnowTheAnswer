using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.ExtensionMethods;

namespace IKnowTheAnswer.Core.Entities
{
    public class Globals
    {
        public const int INVALID_ID = -1;

        private static User LoggedUser;

        private static User DefaultUser = new User();


        public static void SetLoggedUser(User user)
            => LoggedUser = user;

        public static User GetLoggedUser()
            => (LoggedUser == null) ? new User() : LoggedUser;

        public static ResponseDto GetLoggedUserResponse()
        {
            var response = new ResponseDto();
            var loggedUser = GetLoggedUser();

            if (loggedUser.Id.IsIdValid())
            {
                response.Data = loggedUser;
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        public static ResponseDto LogOut()
        {
            var response = new ResponseDto();
            var loggedUser = GetLoggedUser();

            if (loggedUser.Id.IsIdInvalid())
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }
    }
}