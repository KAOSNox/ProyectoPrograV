using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.Models;
using System.Data;
using System.Diagnostics;

namespace ProyectoProgra5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
		{
            _logger = logger;
        }

		public IActionResult Index()
        {
            return View();
        }
    }
}