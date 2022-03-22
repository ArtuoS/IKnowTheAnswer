using IKnowTheAnswer.Presentation.DTOs.Login;
using IKnowTheAnswer.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
            => View();

        [HttpGet]
        public async Task<IActionResult> SignIn()
            => View();

        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] SignInDto signInDto)
        {
            var response = await _loginService.SignIn(signInDto);

            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
    }
}