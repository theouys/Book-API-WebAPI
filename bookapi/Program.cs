using bookapi.Models;
using bookapi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Install dotnet-ef - dotnet tool install --global dotnet-ef
//This is used for EntityFramework
//Create migration scripts  dotnet ef migrations add InitialMigration (last word is a name for it)

//AddScope - Create once per client
//AddSingleton - Same for every request
//Transient - New instance created everytime
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddDbContext<BookContext>(option => option.UseSqlite("Data source=books.db"));

builder.Services.AddControllers();
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

app.Run();
