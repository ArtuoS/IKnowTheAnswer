using IKnowTheAnswer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTheAnswer.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseDto<UserDto>> Insert(UserDto userDto);
        Task<ResponseDto<UserDto>> Update(UserDto userDto);
        Task<ResponseDto<UserDto>> Delete(int id);
        Task<ResponseDto<UserDto>> Get(int id);
        Task<ResponseDto<IList<UserDto>>> GetAll();
        Task<ResponseDto<UserDto>> GetByLoginAndPassword(string login, string password);

    }
}
