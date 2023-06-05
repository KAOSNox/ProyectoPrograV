using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;
using System.Data;


namespace ProyectoProgra5.Controllers
{
	[Authorize(Roles = "Administrador")]
	public class CargosController : Controller
	{
		private readonly ProyectoProgra5Context _context;

		public CargosController(ProyectoProgra5Context context)
		{
			_context = context;
		}
        public IActionResult Index()
        {
            List<Cargo> cargos = _context.Cargos.ToList();
            return View(cargos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cargo cargosPublicoModel)
        {
            Cargo cargos = new Cargo()
            {
                Nombre = cargosPublicoModel.Nombre,
                Descripcion = cargosPublicoModel.Descripcion,
            };

            _context.Cargos.Add(cargos);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            Cargo? cargos = _context.Cargos.FirstOrDefault(x => x.Id == id);
            if (cargos != null)
            {
                return View(cargos);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Cargo cargosModel)
        {
            Cargo? cargos = _context.Cargos.FirstOrDefault(x => x.Id == id);
            if (cargos != null)
            {
                cargos.Nombre = cargosModel.Nombre;
                cargos.Descripcion = cargosModel.Descripcion;
                _context.Cargos.Update(cargos);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Cargo? cargos = _context.Cargos.FirstOrDefault(x => x.Id == id);
            if (cargos != null)
            {
                _context.Cargos.Remove(cargos);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
