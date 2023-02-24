﻿using Microsoft.EntityFrameworkCore;
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
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Film_Language> Film_Languages { get; set; } = null!;
    public DbSet<Format> Formats { get; set; } = null!;
    public DbSet<Film_Format> Film_Formats{ get; set; } = null!;
    public DbSet<Subtitle> Subtitles{ get; set; } = null!;
    public DbSet<Film_Subtitle> Film_Subtitles{ get; set; } = null!;
    public DbSet<Cinema> Cinemas{ get; set; } = null!;
    





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //!Apply all configurations in this assembyly 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmConfiguration).Assembly);


    }

}
