using AutoMapper;
using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.Models;
using IKnowTheAnswer.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IKnowTheAnswer.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _userService.GetLoggedUser();

            ViewBag.LoggedUser = response.Success ? $"Welcome, {_mapper.Map<UserGetDto>(response.Data).Name}" : string.Empty;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}