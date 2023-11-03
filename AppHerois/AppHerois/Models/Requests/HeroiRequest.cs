namespace AppHerois.Models.Requests
{
    public class HeroiRequest
    {
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<SuperPoderesModel> SuperPoderes { get; set; }
        public Guid? Id { get; set; }
    }
}
