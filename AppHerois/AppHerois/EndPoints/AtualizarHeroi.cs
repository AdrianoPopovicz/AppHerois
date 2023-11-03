using AppHerois.Infra;
using AppHerois.Models.Requests;
using AppHerois.Models;
using Microsoft.EntityFrameworkCore;

namespace AppHerois.EndPoints
{
    public class AtualizarHeroi
    {
        public static string Template => "/atualizar_heroi";
        public static string[] Methods => new string[] { HttpMethod.Patch.ToString() };
        public static Delegate Handle => Action;


        public static async Task<IResult> Action(HeroiRequest request, ApplicationDbContext context)
        {
            if (request != null)
            {
                if(request.Id == null)
                {
                    return Results.BadRequest("É necessário informar o Id do heroi");
                }
                HeroiModel heroiParaAtualizar = context.Herois.Where(p => p.Id == request.Id).FirstOrDefault();
                var heroiExistente = context.Herois.Where(p => p.NomeHeroi == request.NomeHeroi).FirstOrDefault();
                if (heroiExistente != null)
                {
                    return Results.Conflict("Já existe um herói com esse nome! Por favor escolha outro");
                }
                heroiParaAtualizar.Id = (Guid)request.Id;
                heroiParaAtualizar.Nome = request.Nome;
                heroiParaAtualizar.NomeHeroi = request.NomeHeroi;
                heroiParaAtualizar.DataNascimento = request.DataNascimento;
                heroiParaAtualizar.Altura = request.Altura;
                heroiParaAtualizar.Peso = request.Peso;
                heroiParaAtualizar.Nome = request.Nome;
                context.Herois.Update(heroiParaAtualizar);

                if (request.SuperPoderes == null)
                {
                    return Results.BadRequest("É necessário informar pelo menos um poder do herói");
                }

                if (request.SuperPoderes.Count > 0)
                {
                    foreach (SuperPoderesModel poder in request.SuperPoderes)
                    {
                        context.SuperPoderes.Update(poder);
                        await context.SaveChangesAsync();
                    }
                }
                return Results.Created($"/herois/{heroiParaAtualizar.Id}", heroiParaAtualizar.Id);
            }
            else
            {
                return Results.BadRequest("É necessário informar um herói");
            }
        }
    }
}
