using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.Models;
using ProyectoProgra5.Models.Votaciones;

namespace ProyectoProgra5.Controllers
{
    public class EstadisticaController : Controller
    {
        private readonly ProyectoProgra5Context _context;
        public EstadisticaController(ProyectoProgra5Context context) { 
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getChartData()
        {
            ChartData chartData = new ChartData();

            List<Cargo> cargoList = _context.Cargos.ToList();
            List<Partido> partidos = _context.Partidos.ToList();
            List<Votacione> votaciones = _context.Votaciones.ToList();
            List<Candidato> candidatos = _context.Candidatos.ToList();

            foreach(Cargo cargo in cargoList)
            {
                chartData.Cargos.Add(cargo.Nombre);
                foreach(Candidato candidato in candidatos)
                {
                    if(candidato.Cargo == candidato.Cargo)
                    {
                        int idPartido = partidos.FirstOrDefault(x  => x.Nombre == candidato.Partido).Id;
                        var Votos = _context.Votaciones.Where(x => x.IdPartido == idPartido).Select(x => x.Votos).ToList().Sum();
                        chartData.partidosVotos.Add(new PartidosVotos()
                        {
                            name = candidato.Partido,
                            data = new List<int>() { (int)Votos}
                        });
                    }
                }

            }

            return Json(chartData);
        }
    }
}
