using AutoMapper;
using IKnowTheAnswer.Core.DTOs.User;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserInsertDto userInsertDto)
        {
            var response = await _userRepository.Insert(userInsertDto);

            if (response.Success)
            {
                var user = _mapper.Map<User>(response.Data);
                return CreatedAtAction(nameof(GetById), new { Id = user.Id }, response.Data);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _userRepository.Get(id);

            if (response.Success)
            {
                var userDto = _mapper.Map<UserGetDto>(response.Data);
                return Ok(userDto);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("logged-user")]
        public IActionResult GetLoggedUser()
        {
            var response = Globals.GetLoggedUserResponse();

            if (response.Success)
            {
                var userDto = _mapper.Map<UserGetDto>(response.Data);
                return Ok(userDto);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userRepository.GetAll();

            if (response.Success)
            {
                var userDto = _mapper.Map<IList<UserGetDto>>(response.Data);
                return Ok(userDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        private async Task<IActionResult> Delete(int id)
        {
            var response = await _userRepository.Delete(id);

            if (response.Success)
            {
                return NoContent();
            }

            return BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        private async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var response = await _userRepository.Update(id, userUpdateDto);

            if (response.Success)
            {
                return NoContent();
            }

            return BadRequest(response.Message);
        }
    }
}