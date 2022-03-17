using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.DTOs.User;

namespace IKnowTheAnswer.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseDto> Insert(UserInsertDto userInsertDto);

        Task<ResponseDto> Update(int id, UserUpdateDto userUpdateDto);

        Task<ResponseDto> Delete(int id);

        Task<ResponseDto> Get(int id);

        Task<ResponseDto> GetAll();

        Task<ResponseDto> GetByLoginAndPassword(string login, string password);
    }
}