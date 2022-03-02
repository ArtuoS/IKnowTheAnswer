using System.Linq;
using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;
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

        public Task<ResponseDto<UserDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<UserDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<IList<UserDto>>> GetAll()
        {
            var responseDto = new ResponseDto<IList<UserDto>>();

            try
            {
                await using var db = _db;
                var users = await db.Users.ToListAsync();

                if (users.Any())
                {
                    responseDto.Data = _mapper.Map<IList<UserDto>>(users);
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

        public async Task<ResponseDto<UserDto>> GetByLoginAndPassword(string login, string password)
        {
            var responseDto = new ResponseDto<UserDto>();

            try
            {
                await using var db = _db;
                var user = db.Users.Where(x => x.Email == login && x.Password == password)
                                             .FirstOrDefaultAsync();

                if (user.Result.Id > 0)
                {
                    responseDto.Data = _mapper.Map<UserDto>(user);
                    responseDto.Success = true;
                    responseDto.Message = $"Select User {user.Result.Name}!";
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto<UserDto>> Insert(UserDto userDto)
        {
            var responseDto = new ResponseDto<UserDto>();

            try
            {
                await using var db = _db;
                var user = _mapper.Map<User>(userDto);

                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                responseDto.Data = _mapper.Map<UserDto>(user);
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

        public Task<ResponseDto<UserDto>> Update(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}