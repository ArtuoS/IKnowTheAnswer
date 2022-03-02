using AutoMapper;
using IKnowTheAnswer.Application.Models.Views;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IKnowTheAnswer.PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
            => View();

        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post([FromForm] UserPostViewModel userPostViewModel)
        {
            var userDto = _mapper.Map<UserDto>(userPostViewModel);

            var response = _userRepository.Insert(userDto);

            if (!response.Result.Success)
                return BadRequest(response.Result.Message);

            return Ok(response.Result.Data);
        }
    }
}