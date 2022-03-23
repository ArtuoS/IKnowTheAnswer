using IKnowTheAnswer.Application.DTOs;
using IKnowTheAnswer.Application.Interfaces;
using IKnowTheAnswer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            var response = await _loginService.SignIn(signInDto);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            var response = Globals.LogOut();

            if (response.Success)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}