using AppHerois.Infra;
using AppHerois.Models;
using AppHerois.Models.Requests;
using AppHerois.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AppHerois.EndPoints
{
    public class GetAllHerois
    {
        public static string Template => "/herois";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static async Task<IResult> Action(ApplicationDbContext context)
        {
            
            List<HeroisResponse> response = new List<HeroisResponse>();
            var herois = context.Herois.ToList();
            if(herois == null)
            {
                return Results.NoContent();
            }
            foreach(HeroiModel heroiModel in herois)
            {
                var heroiResponse = new HeroisResponse(heroiModel.Id, heroiModel.Nome, heroiModel.NomeHeroi, heroiModel.DataNascimento, heroiModel.Altura, heroiModel.Peso);
                response.Add(heroiResponse);
            }
            var results = response;
            return Results.Ok(results);
        }
    }
}
