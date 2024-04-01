using FluentAssertions.Common;
using MediatR;
using Questao5.Infrastructure.Sqlite;
using Questao5.Repositories;
using Questao5.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Services
builder.Services.AddScoped<MovimentacaoContaCorrenteService>();
builder.Services.AddScoped<SaldoContaCorrenteService>();
// Add repository
builder.Services.AddScoped<IMovimentoContaCorrenteRepository, MovimentoRepository>(provider =>
{
    var connectionString = "Server=GUSTAVO\\MSSQLSERVER01;Database=teste;Integrated Security=True;";
    return new MovimentoRepository(connectionString);
});

builder.Services.AddScoped<IContaCorrenteRepository>(provider =>
{
    var connectionString = "Server=GUSTAVO\\MSSQLSERVER01;Database=teste;Integrated Security=True;";
    return new ContaCorrenteRepository(connectionString);
});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html
