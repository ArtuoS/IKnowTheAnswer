using IKnowTheAnswer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
    }
}