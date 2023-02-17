using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Implementations;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.DataAccess.Contexts;
using ParkCinema.DataAccess.Interfaces;
using ParkCinema.DataAccess.Repositories;
using ParkCinema.Business.Validators.Film;

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

//Repo
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFilm_GenreRepository,Film_GenreRepository>();
builder.Services.AddScoped<IFilm_LanguageRepository,Film_LanguageRepository>();
builder.Services.AddScoped<IFilm_FormatRepository,Film_FormatRepository>();
builder.Services.AddScoped<IFilm_SubtitleRepository,Film_SubtitleRepository>();
builder.Services.AddScoped<ISubtitleRepository,SubtitleRepository>();
builder.Services.AddScoped<IFormatRepository,FormatRepository>();
builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<ILanguageRepository,LanguageRepository>();


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
