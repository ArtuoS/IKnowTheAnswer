using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.DTOs.User;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.ExtensionMethods;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Infrastructure.Repositories.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IKnowTheAnswer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IKnowTheAnswerDbContext _db;
        private readonly IMapper _mapper;

        public UserRepository(IKnowTheAnswerDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Delete(int id)
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                    if (user != null && user.Id.IsIdValid())
                    {
                        db.Users.Remove(user);
                        await db.SaveChangesAsync();

                        responseDto.Success = true;
                        responseDto.Message = "Deleted!";
                    }
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto> Get(int id)
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var users = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                    if (users != null && users.Id.IsIdValid())
                    {
                        responseDto.Data = users;
                        responseDto.Success = true;
                        responseDto.Message = $"Selected User {users.Name}!";
                    }
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto> GetAll()
        {
            var responseDto = new ResponseDto();

            try
            {
                await using var db = _db;
                var users = await db.Users.ToListAsync();

                if (users.Any())
                {
                    responseDto.Data = users;
                    responseDto.Success = true;
                    responseDto.Message = "Selected All Users!";
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto> GetByLoginAndPassword(string login, string password)
        {
            var responseDto = new ResponseDto();

            try
            {
                await using var db = _db;
                var user = await db.Users.FirstOrDefaultAsync(x => x.Email == login && x.Password == password);

                if (user != null && user.Id.IsIdValid())
                {
                    responseDto.Data = _mapper.Map<User>(user);
                    responseDto.Success = true;
                    responseDto.Message = $"User Logged In {user.Name}!";
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto> Insert(UserInsertDto userInsertDto)
        {
            var responseDto = new ResponseDto();

            try
            {
                await using var db = _db;
                var user = _mapper.Map<User>(userInsertDto);

                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                responseDto.Data = user;
                responseDto.Success = true;
                responseDto.Message = "Created!";
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto> Update(int id, UserUpdateDto userUpdateDto)
        {
            var responseDto = new ResponseDto();

            try
            {
                await using var db = _db;
                var oldUser = await db.Users.FirstOrDefaultAsync(w => w.Id == id);

                if (oldUser != null && oldUser.Id.IsIdValid())
                {
                    var updatedUser = _mapper.Map(userUpdateDto, oldUser);

                    db.Users.Update(updatedUser);
                    await db.SaveChangesAsync();

                    responseDto.Data = updatedUser;
                    responseDto.Success = true;
                    responseDto.Message = "Updated!";
                }
                else
                {
                    responseDto.Success = false;
                    responseDto.Message = "User not found!";
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }
    }
}