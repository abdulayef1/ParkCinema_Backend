using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkCinema.API.Extensions;
using ParkCinema.Business;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Validators.Film;
using ParkCinema.Core.Entities.Identity;
using ParkCinema.DataAccess;
using ParkCinema.DataAccess.Contexts;
using ParkCinema.Infrastructure;
using ParkCinema.Infrastructure.Services.Payment.Stripe;
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

//Services
builder.Services.AddBusinessServices();

//Storage
builder.Services.AddStorage<AzureStorage>();

//Payment
builder.Services.AddPayment<StripePayment>();

//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;

    options.User.RequireUniqueEmail = true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);
    options.Lockout.AllowedForNewUsers = true;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Auth/Login";
});



builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(typeof(FilmDTO).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors();

//Exception Handler
app.ConfigureCustomExceptionMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


