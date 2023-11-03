namespace AppHerois.Models.Requests
{
    public record HeroisResponse(Guid Id, string Nome, string NomeHeroi, DateTime DataNascimento, double Altura, double Peso);
}
