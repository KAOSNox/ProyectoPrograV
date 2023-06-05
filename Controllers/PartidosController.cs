using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;


namespace ProyectoProgra5.Controllers
{
	public class PartidosController : Controller
	{
		private readonly ProyectoProgra5Context _context;

		public PartidosController(ProyectoProgra5Context context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			List<Partido> partidos = _context.Partidos.ToList();
            return View(partidos);
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Partido partidoModel)
        {
            Partido partido = new Partido()
            {
                Nombre = partidoModel.Nombre,
                Fundacion = partidoModel.Fundacion,
                Lider = partidoModel.Lider,
            };

            _context.Partidos.Add(partido);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            Partido? partido = _context.Partidos.FirstOrDefault(x => x.Id == id);
            if (partido != null)
            {
                return View(partido);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Partido partidoModel)
        {
            Partido? partido = _context.Partidos.FirstOrDefault(x => x.Id == id);
            if (partido != null)
            {
                partido.Nombre = partidoModel.Nombre;
                partido.Fundacion = partidoModel.Fundacion;
                partido.Lider = partidoModel.Lider;
                _context.Partidos.Update(partido);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Partido? partido = _context.Partidos.FirstOrDefault(x => x.Id == id);
            if (partido != null)
            {
                _context.Partidos.Remove(partido);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
