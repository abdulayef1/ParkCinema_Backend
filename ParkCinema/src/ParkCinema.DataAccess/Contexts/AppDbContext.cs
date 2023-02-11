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
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Film_Genre> Film_Genres { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //!Apply all configurations in this assembyly 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmConfiguration).Assembly);

        //!Configuration of many to many  relationship between film and genres
        modelBuilder.Entity<Film_Genre>()
            .HasKey(fg => new { fg.Film_Id, fg.Genre_Id });

        modelBuilder.Entity<Film_Genre>()
            .HasOne<Genre>(fg => fg.Genre)
            .WithMany(g => g.Film_Genres)
            .HasForeignKey(fg => fg.Genre_Id);

        modelBuilder.Entity<Film_Genre>()
            .HasOne<Film>(fg => fg.Film)
            .WithMany(g => g.Film_Genres)
            .HasForeignKey(fg => fg.Film_Id);
    }

}
