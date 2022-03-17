using IKnowTheAnswer.PresentationLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetById()
            => View();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _userService.GetById(id);
            return Ok(response.Result.Data);
        }
    }
}