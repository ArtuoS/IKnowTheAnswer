using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTheAnswer.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public IList<Tuple<int, string>> UserToListItem(IList<UserDto> usersDto)
        {
            var listItems = new List<Tuple<int, string>>();

            foreach (var user in usersDto)
            {
                listItems.Add(new Tuple<int, string>(user.Id, user.Name));
            }

            return listItems;
        }
    }
}
