using AutoMapper;
using IKnowTheAnswer.Core.DTOs.User;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Api.Controllers
{
    [Route("[controller]")]
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
        public IActionResult Insert([FromBody] UserInsertDto userInsertDto)
        {
            var response = _userRepository.Insert(userInsertDto);

            if (response.Result.Success)
            {
                var user = _mapper.Map<User>(response.Result.Data);
                return CreatedAtAction(nameof(GetById), new { Id = user.Id }, response.Result.Data);
            }

            return BadRequest(response.Result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _userRepository.Get(id);

            if (response.Result.Success)
            {
                var userDto = _mapper.Map<UserGetDto>(response.Result.Data);
                return Ok(userDto);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _userRepository.GetAll();

            if (response.Result.Success)
            {
                var userDto = _mapper.Map<IList<UserGetDto>>(response.Result.Data);
                return Ok(userDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        private IActionResult Delete(int id)
        {
            var response = _userRepository.Delete(id);

            if (response.Result.Success)
            {
                return NoContent();
            }

            return BadRequest(response.Result.Message);
        }

        [HttpPut("{id}")]
        private IActionResult Update(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var response = _userRepository.Update(id, userUpdateDto);

            if (response.Result.Success)
            {
                return NoContent();
            }

            return BadRequest(response.Result.Message);
        }
    }
}