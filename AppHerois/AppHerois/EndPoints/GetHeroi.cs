using AppHerois.Infra;
using AppHerois.Models;
using AppHerois.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AppHerois.EndPoints
{
    public class GetHeroi
    {
        public static string Template => "/recuperar_heroi/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;


        public static async Task<IResult> Action([FromRoute] Guid? id, ApplicationDbContext context)
        {
            if (id == null)
            {
                return Results.BadRequest("É necessário informar o Id do heroi");
            }
            List<SuperPoderesModel> superPoderes = new List<SuperPoderesModel>();
            HeroiModel heroiModel = context.Herois.Where(p => p.Id == id).FirstOrDefault();
            var HeroiPoderes = context.HeroisPoderes.Where(p => p.HeroiId == heroiModel.Id.ToString());
            var poderes = context.SuperPoderes.ToList();
            foreach (HeroisSuperpoderesModel poder in HeroiPoderes)
            {
                var poderRecuperado = poderes.Find(p => p.Id.ToString() == poder.SuperpoderId);
                superPoderes.Add(poderRecuperado);
            }
            

            HeroiResponse response = new HeroiResponse(heroiModel.Id, heroiModel.Nome, heroiModel.NomeHeroi, heroiModel.DataNascimento, heroiModel.Altura, heroiModel.Peso, superPoderes);
            return Results.Ok(response);
        }
    }
}
