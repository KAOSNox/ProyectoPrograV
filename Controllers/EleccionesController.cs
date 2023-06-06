using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;
using System.Data;


namespace ProyectoProgra5.Controllers
{
	[Authorize(Roles = "Administrador")]
	public class EleccionesController : Controller
	{
		
		private readonly ProyectoProgra5Context _context;

		public EleccionesController(ProyectoProgra5Context context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			List<Eleccione> elecciones = _context.Elecciones.ToList();
            return View(elecciones);
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Eleccione eleccioneModel)
        {
            Eleccione elecciones = new Eleccione()
            {
                Nombre = eleccioneModel.Nombre,
                Fecha = eleccioneModel.Fecha,
                Descripcion = eleccioneModel.Descripcion,
            };

            _context.Elecciones.Add(elecciones);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            Eleccione? elecciones = _context.Elecciones.FirstOrDefault(x => x.Id == id);
            if (elecciones != null)
            {
                return View(elecciones);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Eleccione eleccioneModel)
        {
            Eleccione? elecciones = _context.Elecciones.FirstOrDefault(x => x.Id == id);
            if (elecciones != null)
            {
                elecciones.Nombre = eleccioneModel.Nombre;
                elecciones.Fecha = eleccioneModel.Fecha;
                elecciones.Descripcion = eleccioneModel.Descripcion;
                _context.Elecciones.Update(elecciones);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Eleccione? elecciones = _context.Elecciones.FirstOrDefault(x => x.Id == id);
            if (elecciones != null)
            {
                _context.Elecciones.Remove(elecciones);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
