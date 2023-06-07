namespace ProyectoProgra5.Models.Votaciones
{
    public class ChartData
    {
        public List<PartidosVotos> partidosVotos { get; set; } = new List<PartidosVotos>();
        public List<string> Cargos { get; set; } = new List<string>();
    }

    public class PartidosVotos
    {
        public string name { get; set; }
        public List<int> data { get; set; } = new List<int>();
    }
}
