using RestWithAspNet.Services;
using RestWithAspNet.Services.Impl;
using RestWithAspNet.Configurations;
using RestWithAspNet.Repositories;
using RestWithAspNet.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

//Person
builder.Services.AddScoped<IPersonServices, PersonSerivecesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

//Book
builder.Services.AddScoped<IBookServices, BookServicesImpl>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
