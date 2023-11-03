namespace AppHerois.Models.Responses
{
    public record HeroiResponse(Guid Id, string Nome, string NomeHeroi, DateTime DataNascimento, double Altura, double Peso, List<SuperPoderesModel> SuperPoderes);
    
}
