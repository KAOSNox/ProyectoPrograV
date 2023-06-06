using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;
using System.Data;
using System.Diagnostics;

namespace ProyectoProgra5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProyectoProgra5Context _context;

        public HomeController(ILogger<HomeController> logger, ProyectoProgra5Context context)
		{
            _logger = logger;
            _context = context;
        }

		public IActionResult Index()
        {
            ViewBag.Usuarios = _context.Users.Count();
            ViewBag.Candidatos = _context.Candidatos.Count();
            ViewBag.Partidos = _context.Partidos.Count();
            ViewBag.Cargos = _context.Cargos.Count();
            return View();
        }
    }
}