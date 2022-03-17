using IKnowTheAnswer.Application.Interfaces;
using IKnowTheAnswer.Application.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult LogIn([FromBody] LoginInputModel loginInputModel)
        {
            var response = _loginService.Login(loginInputModel);

            if (response.Result.Success)
            {
                return Ok(response.Result.Message);
            }

            return NotFound();
        }
    }
}