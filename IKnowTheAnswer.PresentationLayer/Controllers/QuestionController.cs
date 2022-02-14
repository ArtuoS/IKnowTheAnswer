using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Enums;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.PresentationLayer.Controllers
{
    [Route("[controller]")]
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _questionRepository.Get(id);

            if (!response.Result.Success)
                return NotFound();

            return Ok(response.Result.Data);
        }

        [HttpGet]
        public IActionResult Post()
        {
            var users = _userRepository.GetAll();

            if (users.Result.Data.Any())
                ViewBag.Users = _userService.UserToListItem(users.Result.Data);

            return View();
        }

        [HttpPost]
        public IActionResult Post(QuestionDto questionDto)
        {
            var response = _questionRepository.Insert(questionDto);

            if (!response.Result.Success)
                return BadRequest(response.Result.Message);

            var question = _mapper.Map<Question>(questionDto);
            var questionLogger = new QuestionLoggerDto(questionDto.User, question, EQuestionLogType.Insert);
            _questionLoggerRepository.Log(questionLogger);

            return Ok(response.Result.Data);
        }
    }
}
