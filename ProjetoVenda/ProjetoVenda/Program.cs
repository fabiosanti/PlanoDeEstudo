using Interfaces.Repositorio;
using Interfaces.Servicos;
using Microsoft.EntityFrameworkCore;
using PV.Repositorio.Contexto;
using PV.Repositorio.Repositorio;
using PV.Servico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContexto>(option => option.UseSqlite("name=ConnectionStrings:connection"));

builder.Services.AddScoped<IProdutoServico, ProdutoServico>();

builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
