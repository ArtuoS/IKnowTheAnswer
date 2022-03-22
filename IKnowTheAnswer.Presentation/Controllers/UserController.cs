using IKnowTheAnswer.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IKnowTheAnswer.Presentation.Controllers
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
        public async Task<IActionResult> UserIndex()
        {
            var response = await _userService.GetAll();

            if (response.Success)
            {
                return View(response.Data);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var response = await _userService.DeleteAsync(id);

            if (response.Success)
            {
                RedirectToAction("UserIndex");
            }

            return NotFound();
        }
    }
}