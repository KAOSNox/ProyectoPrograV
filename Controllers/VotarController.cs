using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.Models;
using ProyectoProgra5.Models.VotacionModel;
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
                List<Cargo> cargos = _context.Cargos.ToList();

                VotacionModel[] votacionCargos = new VotacionModel[cargos.Count];
                

                foreach (var item in cargos)
                {

                    int idUser = int.Parse(User.FindFirstValue("IDUser"));

                    bool voto = _context.Cargos.Any();

                    votacionCargos[cargos.IndexOf(item)] = new VotacionModel()
                    {
                        nombreCargo = item.Nombre,
                        idUser = idUser,
                        voto = voto,
                        candidatos = _context.Candidatos.Where(x => x.Cargo == item.Nombre).ToList(),
                        candidatoscheckbox = new bool[_context.Candidatos.Where(x => x.Cargo == item.Nombre).Count()],
                    };
                    Array.Fill(votacionCargos[cargos.IndexOf(item)].candidatoscheckbox, false);
                }
                return View(votacionCargos);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Votacion(int id, string cargo, VotacionModel votacionCargos)
        {
            /*try
            {
                bool voto = _context.Votacions.Any(x => x.IdUsuario == id);

                if (!voto)
                {
                    Votacion votacion = new Votacion()
                    {
                        IdCandidato = votacionModel.CandidatoID,
                        IdUsuario = id,
                    };
                    _context.Votacions.Add(votacion);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }*/
            return RedirectToAction("Index");
        }
    }
}
