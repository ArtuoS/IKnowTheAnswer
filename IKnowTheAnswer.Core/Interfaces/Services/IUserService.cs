using IKnowTheAnswer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTheAnswer.Core.Interfaces.Services
{
    public interface IUserService
    {
        IList<Tuple<int, string>> UserToListItem(IList<UserDto> usersDto);
    }
}
