using AppHerois.EndPoints;
using AppHerois.Infra;
using AppHerois.Models;
using AppHerois.Models.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsql<ApplicationDbContext>(builder.Configuration["Database:Npgsql"]);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(ManterHeroi.Template, ManterHeroi.Methods, ManterHeroi.Handle);
app.MapMethods(GetAllHerois.Template, GetAllHerois.Methods, GetAllHerois.Handle);
app.MapMethods(AtualizarHeroi.Template, AtualizarHeroi.Methods, AtualizarHeroi.Handle);
app.MapMethods(RemoverHeroi.Template, RemoverHeroi.Methods, RemoverHeroi.Handle);
app.MapMethods(GetHeroi.Template, GetHeroi.Methods, GetHeroi.Handle);

app.Run();
