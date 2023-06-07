using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.Models;
using ProyectoProgra5.Models.Votaciones;
using System;
using System.Security.Claims;

namespace ProyectoProgra5.Controllers
{
    public class VotarController : Controller
    {
        private readonly ProyectoProgra5Context _context;
        public VotarController(ProyectoProgra5Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var Elecciones = _context.Elecciones.ToList();
                var Partido = _context.Partidos.ToList();
                List<Votaciones> votacione = _context.Votaciones.Select(x => new Votaciones
                {
                    Id = x.Id,
                    Elecciones = _context.Elecciones.FirstOrDefault(v => v.Id == x.IdElecciones).Nombre,
                    Partido = _context.Partidos.FirstOrDefault(v => v.Id == x.IdPartido).Nombre,
                    Mesa = x.Mesa,
                    Votos = (int)x.Votos
                }).ToList();

                return View(votacione);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult Create()
        {
            VotacionesCreate votacionesCreate = new VotacionesCreate()
            {
                eleccionesList = _context.Elecciones.ToList(),
                partidosList = _context.Partidos.ToList()
            };
            return View(votacionesCreate);
        }

        [HttpPost]
        public IActionResult Create(VotacionesCreate votacionesModel)
        {
            try
            {
                Votacione votacione = new Votacione()
                {
                    IdElecciones = votacionesModel.Elecciones,
                    IdPartido = votacionesModel.Partido,
                    Mesa = votacionesModel.Mesa,
                    Votos = votacionesModel.Votos
                };

                _context.Votaciones.Add(votacione);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var Votacion = _context.Votaciones.FirstOrDefault(x => x.Id == id);
            VotacionesCreate votacionesCreate = new VotacionesCreate()
            {
                Id = id,
                Elecciones = _context.Elecciones.FirstOrDefault(v => v.Id == Votacion.IdElecciones).Id,
                Partido = _context.Partidos.FirstOrDefault(v => v.Id == Votacion.IdPartido).Id,
                Mesa = Votacion.Mesa,
                Votos = (int)Votacion.Votos,
                eleccionesList = _context.Elecciones.ToList(),
                partidosList = _context.Partidos.ToList()
            };
            return View(votacionesCreate);
        }

        [HttpPost]
        public IActionResult Edit(int id, VotacionesCreate votacion)
        {
            try
            {
                Votacione votacione = _context.Votaciones.FirstOrDefault(x => x.Id == id);

                votacione.IdElecciones = votacion.Elecciones;
                votacione.IdPartido = votacion.Partido;
                votacione.Mesa = votacion.Mesa;
                votacione.Votos = votacion.Votos;

                _context.Votaciones.Update(votacione);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Votacione votacione = _context.Votaciones.FirstOrDefault(x => x.Id == id);
                _context.Remove(votacione);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
