using IKnowTheAnswer.Application.Interfaces;
using IKnowTheAnswer.Application.Models.Input;
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

        [HttpGet]
        public async Task<IActionResult> SignIn([FromBody] SignInInputModel loginInputModel)
        {
            var response = await _loginService.SignIn(loginInputModel);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return NotFound();
        }
    }
}