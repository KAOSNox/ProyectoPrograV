namespace ProyectoProgra5.Models.VotacionModel
{
    public class VotacionModel
    {
        public string nombreCargo { get; set; }
        public int idUser { get; set; }
        public List<Candidato> candidatos {get;set;}

        public bool[] candidatoscheckbox { get; set; }

        public int CandidatoID { get; set; }

        public bool voto { get; set; }
    }
}
