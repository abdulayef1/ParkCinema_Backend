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
        return await _filmRepository.FindAll().ToListAsync();
    }
}
