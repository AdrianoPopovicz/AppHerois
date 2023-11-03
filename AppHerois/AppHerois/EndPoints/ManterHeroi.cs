using AppHerois.Infra;
using AppHerois.Models;
using AppHerois.Models.Requests;
using System.Security.Claims;

namespace AppHerois.EndPoints
{
    public class ManterHeroi
    {
        public static string Template => "/manter_heroi";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;


        public static async Task<IResult> Action(HeroiRequest request, ApplicationDbContext context)
        {
            if (request != null)
            {
                var heroiExistente = context.Herois.Where(p => p.NomeHeroi == request.NomeHeroi).FirstOrDefault();
                if (heroiExistente != null)
                {
                    return Results.Conflict("Já existe um herói com esse nome! Por favor escolha outro");
                }
                var heroi = new HeroiModel()
                {
                    Nome = request.Nome,
                    NomeHeroi = request.NomeHeroi,
                    DataNascimento = request.DataNascimento,
                    Altura = request.Altura,
                    Peso = request.Peso,
                };

                if (request.SuperPoderes == null)
                {
                    return Results.BadRequest("É necessário informar pelo menos um poder do herói");
                }
                if (request.SuperPoderes.Count > 0)
                {
                    foreach (SuperPoderesModel poder in request.SuperPoderes)
                    {
                        var poderHeroi = new SuperPoderesModel()
                        {
                            SuperPoder = poder.SuperPoder,
                            Descricao = poder.Descricao,
                        };
                        await context.SuperPoderes.AddAsync(poderHeroi);
                        await context.SaveChangesAsync();

                        var superPoderHeroi = new HeroisSuperpoderesModel()
                        {
                            HeroiId = heroi.Id.ToString(),
                            SuperpoderId = poderHeroi.Id.ToString(),
                        };
                        await context.HeroisPoderes.AddAsync(superPoderHeroi);
                        await context.SaveChangesAsync();
                    }
                }
                else
                {
                    return Results.BadRequest("É necessário informar pelo menos um poder do herói");
                }
                await context.Herois.AddAsync(heroi);
                await context.SaveChangesAsync();
                return Results.Created($"/herois/{heroi.Id}", heroi.Id);
            }
            else
            {
                return Results.BadRequest("É necessário informar um herói");
            }
        }
    }
}
