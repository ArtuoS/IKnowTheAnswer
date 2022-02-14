using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Interfaces.Repositories;

namespace IKnowTheAnswer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<ResponseDto<UserDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<UserDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<List<UserDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<UserDto>> Insert(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<UserDto>> Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
