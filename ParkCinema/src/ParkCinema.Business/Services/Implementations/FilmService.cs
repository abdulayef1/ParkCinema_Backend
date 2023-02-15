using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Core.Entities;
using ParkCinema.DataAccess.Interfaces;

namespace ParkCinema.Business.Services.Implementations;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly IFilm_GenreRepository _film_GenreRepository;
    private readonly IFilm_FormatRepository _film_FormatRepository;
    private readonly IFilm_LanguageRepository _film_LanguageRepository;
    private readonly IFilm_SubtitleRepository _film_SubtitleRepository;
    private readonly IMapper _mapper;


    public FilmService(IFilmRepository filmRepository,
                       IFilm_GenreRepository film_GenreRepository,
                       IFilm_FormatRepository film_FormatRepository,
                       IFilm_LanguageRepository film_LanguageRepository,
                       IFilm_SubtitleRepository film_SubtitleRepository,
                       IMapper mapper)
    {
        _filmRepository = filmRepository;
        _film_GenreRepository = film_GenreRepository;
        _film_LanguageRepository = film_LanguageRepository;
        _film_SubtitleRepository = film_SubtitleRepository;
        _film_FormatRepository = film_FormatRepository;
        _mapper = mapper;
    }



    //? COMPLETE DTOS, ADD MAPPER AND VALIDATOR
    public async Task<List<FilmDTO>> FindAllAsync()
    {
        var films = await _filmRepository.FindAll()
            .Where(con => con.IsNew == true)
            .Include(fg => fg.Film_Genres).ThenInclude(g => g.Genre)
            .Include(fl => fl.Film_Languages).ThenInclude(fl => fl.Language)
            .Include(ff => ff.Film_Formats).ThenInclude(ff => ff.Format)
            .Include(fs => fs.Film_Subtitles).ThenInclude(fs => fs.Subtitle)
            .ToListAsync();

        List<FilmDTO> filmDTO = _mapper.Map<List<FilmDTO>>(films);
        return filmDTO;
    }
    public async Task CreateAsync(FilmCreateDTO filmDTO)
    {
        var film = _mapper.Map<Film>(filmDTO);
        await _filmRepository.CreateAsync(film);
        await _filmRepository.SaveChangesAsync();

        //!ADD GENRE
        foreach (var id in filmDTO.Genres_Id)
        {
            Film_Genre film_genre = new()
            {
                Genre_Id = id,
                Film_Id = film.Id
            };
            await _film_GenreRepository.CreateAsync(film_genre);
        }

        //!ADD LANGUAGE
        foreach (var id in filmDTO.Languages_Id)
        {
            Film_Language film_language = new()
            {
                Language_Id = id,
                Film_Id = film.Id
            };
            await _film_LanguageRepository.CreateAsync(film_language);
        }

        //!ADD FORMAT
        foreach (var id in filmDTO.Formats_Id)
        {
            Film_Format film_format = new()
            {
                Format_Id = id,
                Film_Id = film.Id
            };
            await _film_FormatRepository.CreateAsync(film_format);

        }

        //!ADD SUBTITTLE
        foreach (var id in filmDTO.Subtitles_Id)
        {
            Film_Subtitle film_subtitle = new()
            {
                Subtitle_Id = id,
                Film_Id = film.Id
            };
            await _film_SubtitleRepository.CreateAsync(film_subtitle);
        }

            await _film_GenreRepository.SaveChangesAsync();
            await _film_LanguageRepository.SaveChangesAsync();
            await _film_FormatRepository.SaveChangesAsync();
            await _film_SubtitleRepository.SaveChangesAsync();
    }


}
