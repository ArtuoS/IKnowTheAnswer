using AutoMapper;
using IKnowTheAnswer.Application.Interfaces;
using IKnowTheAnswer.Application.Models.Input;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Exceptions;
using IKnowTheAnswer.Core.Interfaces.Repositories;

namespace IKnowTheAnswer.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> SignIn(SignInInputModel loginInputModel)
        {
            ValidateCanLogin(loginInputModel);

            var response = _userRepository.GetByLoginAndPassword(loginInputModel.Email, loginInputModel.Password);

            if (response.Result.Data != null)
            {
                var user = _mapper.Map<User>(response.Result.Data);
                Globals.SetLoggedUser(user);
            }

            return await response;
        }

        public void ValidateCanLogin(SignInInputModel loginInputModel)
        {
            if (string.IsNullOrEmpty(loginInputModel.Email))
                throw new LoginException("Email");

            if (string.IsNullOrEmpty(loginInputModel.Email))
                throw new LoginException("Password");
        }
    }
}