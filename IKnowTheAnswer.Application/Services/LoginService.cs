using AutoMapper;
using IKnowTheAnswer.Application.DTOs;
using IKnowTheAnswer.Application.Interfaces;
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

        public async Task<ResponseDto> SignIn(SignInDto signInDto)
        {
            ValidateCanSignIn(signInDto);

            var response = await _userRepository.GetByLoginAndPassword(signInDto.Email, signInDto.Password);

            if (response.Data != null)
            {
                var user = _mapper.Map<User>(response.Data);
                Globals.SetLoggedUser(user);
            }

            return response;
        }

        public void ValidateCanSignIn(SignInDto signInDto)
        {
            if (string.IsNullOrEmpty(signInDto.Email))
                throw new LoginException("Email");

            if (string.IsNullOrEmpty(signInDto.Email))
                throw new LoginException("Password");
        }
    }
}