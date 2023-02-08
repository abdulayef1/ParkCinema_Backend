using Microsoft.EntityFrameworkCore;
using ParkCinema.Core.Entities;
using ParkCinema.DataAccess.Configurations;

namespace ParkCinema.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Film> Films { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmConfiguration).Assembly);
    }

}
