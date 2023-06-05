using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;
using System.Data;


namespace ProyectoProgra5.Controllers
{
	[Authorize(Roles = "Administrador")]
	public class CandidatosController : Controller
	{
		private readonly ProyectoProgra5Context _context;

		public CandidatosController(ProyectoProgra5Context context)
		{
			_context = context;
		}

      
        public IActionResult Index()
        {
            
            List<Candidato> candidatos = _context.Candidatos.ToList();
            return View(candidatos);
            
        }

        public IActionResult Create()
        {
            List<Partido> partidos = _context.Partidos.ToList();
            List<Cargo> cargos = _context.Cargos.ToList();
            ViewBag.Partidos = new SelectList(partidos, "Nombre","Nombre" );
            ViewBag.Cargos = new SelectList(cargos, "Nombre", "Nombre");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Candidato candidatosModel)
        {
            Candidato candidatos = new Candidato()
            {
                Nombre = candidatosModel.Nombre,
                Partido = candidatosModel.Partido,
                Cargo = candidatosModel.Cargo,
                Experencia = candidatosModel.Experencia,
            };

            _context.Candidatos.Add(candidatos);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            List<Partido> partidos = _context.Partidos.ToList();
            List<Cargo> cargos = _context.Cargos.ToList();
            ViewBag.Partidos = new SelectList(partidos, "Nombre", "Nombre");
            ViewBag.Cargos = new SelectList(cargos, "Nombre", "Nombre");
            Candidato? candidatos = _context.Candidatos.FirstOrDefault(x => x.Id == id);
            if (candidatos != null)
            {
                return View(candidatos);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Candidato candidatosModel)
        {
            Candidato? candidatos = _context.Candidatos.FirstOrDefault(x => x.Id == id);
            if (candidatos != null)
            {
                candidatos.Nombre = candidatosModel.Nombre;
                candidatos.Partido = candidatosModel.Partido;
                candidatos.Cargo = candidatosModel.Cargo;
                candidatos.Experencia = candidatosModel.Experencia;
                _context.Candidatos.Update(candidatos);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Candidato? candidatos = _context.Candidatos.FirstOrDefault(x => x.Id == id);
            if (candidatos != null)
            {
                _context.Candidatos.Remove(candidatos);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }
}
