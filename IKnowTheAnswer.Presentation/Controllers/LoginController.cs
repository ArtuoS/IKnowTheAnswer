using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Presentation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
            => View();

        [HttpGet]
        [Route("sign_in")]
        public async Task<IActionResult> SignIn()
            => View();
    }
}
