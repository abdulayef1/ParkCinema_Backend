using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Implementations;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Business.Validators.Film;
using ParkCinema.DataAccess;
using ParkCinema.DataAccess.Contexts;
using ParkCinema.Infrastructure;
using ParkCinema.Infrastructure.Services.Storage.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(FilmCreateDTO_Validator).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Repository
builder.Services.AddRepositoryServices();

//Infrastructure
builder.Services.AddInfrastructureServices();

//Storage
builder.Services.AddStorage<AzureStorage>();



builder.Services.AddScoped<IFilmService,FilmService>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAutoMapper(typeof(FilmDTO).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
