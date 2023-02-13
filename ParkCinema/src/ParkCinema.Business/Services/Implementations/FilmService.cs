using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Core.Entities;
using ParkCinema.DataAccess.Interfaces;

namespace ParkCinema.Business.Services.Implementations;

public class FilmService : IFilmService
{

    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public FilmService(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }



    //? COMPLETE DTOS, ADD MAPPER AND VALIDATOR
    public async Task<List<FilmDTO>> FindAllAsync()
    {
        var films = await _filmRepository.FindAll()
            .Where(con => con.IsNew != true)
            .Include(fg => fg.Film_Genres).ThenInclude(g => g.Genre)
            .Include(fl => fl.Film_Languages).ThenInclude(fl => fl.Language)
            .Include(ff => ff.Film_Formats).ThenInclude(ff => ff.Format)
            .Include(fs => fs.Film_Subtitles).ThenInclude(fs => fs.Subtitle)
            .ToListAsync();

        List<FilmDTO> filmDTO = _mapper.Map<List<FilmDTO>>(films);
        return filmDTO;
    }
}
