﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkCinema.DataAccess.Contexts;

#nullable disable

namespace ParkCinema.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParkCinema.Core.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AddressPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CinemaName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MainImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MainImageContainerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MainImageUri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WorkHours")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Cinema_Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageContainerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Cinema_Images");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Actors")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DurationMinute")
                        .HasColumnType("int");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PosterPathOrContainerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Format", b =>
                {
                    b.Property<int>("Film_Id")
                        .HasColumnType("int");

                    b.Property<int>("Format_Id")
                        .HasColumnType("int");

                    b.HasKey("Film_Id", "Format_Id");

                    b.HasIndex("Format_Id");

                    b.ToTable("Film_Formats");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Genre", b =>
                {
                    b.Property<int>("Film_Id")
                        .HasColumnType("int");

                    b.Property<int>("Genre_Id")
                        .HasColumnType("int");

                    b.HasKey("Film_Id", "Genre_Id");

                    b.HasIndex("Genre_Id");

                    b.ToTable("Film_Genres");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Language", b =>
                {
                    b.Property<int>("Film_Id")
                        .HasColumnType("int");

                    b.Property<int>("Language_Id")
                        .HasColumnType("int");

                    b.HasKey("Film_Id", "Language_Id");

                    b.HasIndex("Language_Id");

                    b.ToTable("Film_Languages");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Subtitle", b =>
                {
                    b.Property<int>("Film_Id")
                        .HasColumnType("int");

                    b.Property<int>("Subtitle_Id")
                        .HasColumnType("int");

                    b.HasKey("Film_Id", "Subtitle_Id");

                    b.HasIndex("Subtitle_Id");

                    b.ToTable("Film_Subtitles");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("HallName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfColumn")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRow")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int>("Hall_ID")
                        .HasColumnType("int");

                    b.Property<bool>("IsEmpty")
                        .HasColumnType("bit");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("SeatType_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Hall_ID");

                    b.HasIndex("SeatType_ID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.SeatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Film_Id")
                        .HasColumnType("int");

                    b.Property<int>("Format_Id")
                        .HasColumnType("int");

                    b.Property<int>("Hall_Id")
                        .HasColumnType("int");

                    b.Property<int>("Language_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Subtitle_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Film_Id");

                    b.HasIndex("Format_Id");

                    b.HasIndex("Hall_Id");

                    b.HasIndex("Language_Id");

                    b.HasIndex("Subtitle_Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Subtitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.ToTable("Subtitles");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Cinema_Image", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Cinema", "Cinema")
                        .WithMany("Images")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Format", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Film", "Film")
                        .WithMany("Film_Formats")
                        .HasForeignKey("Film_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Format", "Format")
                        .WithMany("Film_Formats")
                        .HasForeignKey("Format_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Format");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Genre", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Film", "Film")
                        .WithMany("Film_Genres")
                        .HasForeignKey("Film_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Genre", "Genre")
                        .WithMany("Film_Genres")
                        .HasForeignKey("Genre_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Language", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Film", "Film")
                        .WithMany("Film_Languages")
                        .HasForeignKey("Film_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Language", "Language")
                        .WithMany("Film_Languages")
                        .HasForeignKey("Language_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film_Subtitle", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Film", "Film")
                        .WithMany("Film_Subtitles")
                        .HasForeignKey("Film_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Subtitle", "Subtitle")
                        .WithMany("Film_Subtitles")
                        .HasForeignKey("Subtitle_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Subtitle");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Hall", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Seat", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Hall", "Hall")
                        .WithMany("Seats")
                        .HasForeignKey("Hall_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.SeatType", "SeatType")
                        .WithMany("Seats")
                        .HasForeignKey("SeatType_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("SeatType");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Session", b =>
                {
                    b.HasOne("ParkCinema.Core.Entities.Film", "Film")
                        .WithMany("Sessions")
                        .HasForeignKey("Film_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Format", "Format")
                        .WithMany("Sessions")
                        .HasForeignKey("Format_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("Hall_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Language", "Language")
                        .WithMany("Sessions")
                        .HasForeignKey("Language_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkCinema.Core.Entities.Subtitle", "Subtitle")
                        .WithMany("Sessions")
                        .HasForeignKey("Subtitle_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Format");

                    b.Navigation("Hall");

                    b.Navigation("Language");

                    b.Navigation("Subtitle");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Cinema", b =>
                {
                    b.Navigation("Halls");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Film", b =>
                {
                    b.Navigation("Film_Formats");

                    b.Navigation("Film_Genres");

                    b.Navigation("Film_Languages");

                    b.Navigation("Film_Subtitles");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Format", b =>
                {
                    b.Navigation("Film_Formats");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Genre", b =>
                {
                    b.Navigation("Film_Genres");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Hall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Language", b =>
                {
                    b.Navigation("Film_Languages");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.SeatType", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("ParkCinema.Core.Entities.Subtitle", b =>
                {
                    b.Navigation("Film_Subtitles");

                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
