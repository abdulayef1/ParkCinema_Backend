using ParkCinema.Business.DTOs.Format;
using ParkCinema.Business.DTOs.Genre;
using ParkCinema.Business.DTOs.Language;
using ParkCinema.Business.DTOs.Subtitle;
using ParkCinema.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkCinema.Business.DTOs.Film;

public class FilmDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int AgeLimit { get; set; }
    public int DurationMinute { get; set; }
    public string? Country { get; set; }
    public string? Director { get; set; }
    public string? Actors { get; set; }
    public string? Description { get; set; }
    public string? Trailer { get; set; }
    public string? Poster { get; set; }
    public DateTime Date { get; set; }

    // 
    public ICollection<GenreDTO>? Genres { get; set; }
    public ICollection<LanguageDTO>? Film_Languages { get; set; }
    public ICollection<FormatDTO>? Film_Formats { get; set; }
    public ICollection<SubtitleDTO>? Film_Subtitles { get; set; }
}
