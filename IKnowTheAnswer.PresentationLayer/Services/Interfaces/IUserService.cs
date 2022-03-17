using IKnowTheAnswer.PresentationLayer.DTOs;

namespace IKnowTheAnswer.PresentationLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll();

        Task<ResponseDto> GetById(int id);

        Task<ResponseDto> Insert(UserInsertDto userInsertDto);

        Task<ResponseDto> UpdateProductAsync(UserUpdateDto insertUpdateDto);

        Task<ResponseDto> DeleteProductAsync(int id);
    }
}