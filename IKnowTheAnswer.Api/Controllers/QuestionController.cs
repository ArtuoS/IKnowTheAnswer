using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.DTOs.Question;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Enums;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionLoggerRepository _questionLoggerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public QuestionController(IMapper mapper, IQuestionRepository questionRepository, IQuestionLoggerRepository questionLoggerRepository, IUserRepository userRepository, IUserService userService)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionLoggerRepository = questionLoggerRepository;
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _questionRepository.Get(id);

            if (response.Result.Success)
            {
                var questionDto = _mapper.Map<QuestionGetDto>(response.Result.Data);
                return Ok(questionDto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Insert([FromBody] QuestionInsertDto questionDto)
        {
            var response = _questionRepository.Insert(questionDto);

            if (response.Result.Success)
            {
                var question = _mapper.Map<Question>(questionDto);
                var questionLogger = new QuestionLoggerDto(question.User, question, EQuestionLogType.Insert);
                _questionLoggerRepository.Log(questionLogger);

                return CreatedAtAction(nameof(GetById), new { Id = question.Id }, question);
            }

            return BadRequest(response.Result.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _questionRepository.GetAll();

            if (response.Result.Success)
            {
                var questionDto = _mapper.Map<IList<QuestionGetDto>>(response.Result.Data);
                return Ok(questionDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _questionRepository.Delete(id);

            if (response.Result.Success)
            {
                return NoContent();
            }

            return BadRequest(response.Result.Message);
        }

        [HttpPut("{id}")]
        private IActionResult Update(int id, [FromBody] QuestionUpdateDto questionUpdateDto)
        {
            var response = _questionRepository.Update(id, questionUpdateDto);

            if (response.Result.Success)
            {
                return NoContent();
            }

            return BadRequest(response.Result.Message);
        }
    }
}