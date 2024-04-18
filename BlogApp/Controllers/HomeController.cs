using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BlogApp.BLL.Services.IServices;
using BlogApp.DAL.Models;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IMapper mapper, IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            await _homeService.GenerateData();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}