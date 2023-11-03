using AppHerois.Infra;
using AppHerois.Models.Requests;
using AppHerois.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppHerois.EndPoints
{
    public class RemoverHeroi
    {
        public static string Template => "/remover_heroi/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;


        public static async Task<IResult> Action([FromRoute]Guid? id, ApplicationDbContext context)
        {
            if (id == null)
            {
                return Results.BadRequest("É necessário informar o Id do heroi");
            }
            HeroiModel heroiParaAtualizar = context.Herois.Where(p => p.Id == id).FirstOrDefault();
            context.Herois.Remove(heroiParaAtualizar);
            await context.SaveChangesAsync();
            return Results.Ok();
        }
    }
}
