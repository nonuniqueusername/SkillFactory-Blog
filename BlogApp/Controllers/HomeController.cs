using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BlogApp.BLL.Services.IServices;
using BlogApp.DAL.Models;

namespace BlogApp.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
		private readonly ILogger<HomeController> Logger;

		public HomeController(IMapper mapper, IHomeService homeService, ILogger<HomeController> logger)
        {
            _homeService = homeService;
			Logger = logger;
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
		public IActionResult Error(int? statusCode = null)
		{
			if (statusCode.HasValue)
			{
				if (statusCode == 400 || statusCode == 403 || statusCode == 404)
				{
					var viewName = statusCode.ToString();
					Logger.LogError($"Произошла ошибка - {statusCode}\n{viewName}");
					return View(viewName);
				}
				return View("400");
			}
			return View("400");
		}

		//generate error 400
		[Route("GetException400")]
		[HttpGet]
		public IActionResult GetException400()
		{
			try
			{
				throw new HttpRequestException("400");
			}
			catch
			{
				return View("400");
			}
		}

		//generate error 403
		[Route("GetException403")]
		[HttpGet]
		public IActionResult GetException403()
		{
			try
			{
				throw new HttpRequestException("403");
			}
			catch
			{
				return View("403");
			}
		}

		//generate error 404
		[Route("GetException404")]
		[HttpGet]
		public IActionResult GetException404()
		{
			try
			{
				throw new HttpRequestException("404");
			}
			catch
			{
				return View("404");
			}
		}
		
    }
}