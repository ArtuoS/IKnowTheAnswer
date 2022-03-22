using IKnowTheAnswer.Presentation.DTOs;

namespace IKnowTheAnswer.Presentation.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll();
        Task<ResponseDto> GetById(int id);
        Task<ResponseDto> Insert(UserInsertDto userInsertDto);
        Task<ResponseDto> UpdateAsync(UserUpdateDto insertUpdateDto);
        Task<ResponseDto> DeleteAsync(int id);
        Task<ResponseDto> GetLoggedUser();
    }
}