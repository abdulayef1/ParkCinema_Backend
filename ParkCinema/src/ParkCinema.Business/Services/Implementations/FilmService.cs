using Microsoft.EntityFrameworkCore;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Core.Entities;
using ParkCinema.DataAccess.Interfaces;

namespace ParkCinema.Business.Services.Implementations;

public class FilmService : IFilmService
{

    private readonly IFilmRepository _filmRepository;

    public FilmService(IFilmRepository filmRepository)
    {
       _filmRepository = filmRepository;
    }

    public async Task<List<Film>> FindAllAsync()
    {
        
        var films = await _filmRepository.FindAll()
            .Include(fg => fg.Film_Genres).ThenInclude(g => g.Genre)
            .Include(fl => fl.Film_Languages).ThenInclude(fl => fl.Language)
            .Include(ff=>ff.Film_Formats).ThenInclude(ff => ff.Format)
            .Include(fs=>fs.Film_Subtitles).ThenInclude(fs=>fs.Subtitle)
            .ToListAsync();

        return films;
    }
}
