using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Business.Utilities.Exceptions;
using ParkCinema.Core.Entities;
using ParkCinema.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace ParkCinema.Business.Services.Implementations;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly IFilm_GenreRepository _film_GenreRepository;
    private readonly IFilm_FormatRepository _film_FormatRepository;
    private readonly IFilm_LanguageRepository _film_LanguageRepository;
    private readonly IFilm_SubtitleRepository _film_SubtitleRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IFormatRepository _formatRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly ISubtitleRepository _subtitleRepository;
    private readonly IMapper _mapper;


    public FilmService(IFilmRepository filmRepository,
                       IFilm_GenreRepository film_GenreRepository,
                       IFilm_FormatRepository film_FormatRepository,
                       IFilm_LanguageRepository film_LanguageRepository,
                       IFilm_SubtitleRepository film_SubtitleRepository,
                       IGenreRepository genreRepository,
                       IFormatRepository formatRepository,
                       ILanguageRepository languageRepository,
                       ISubtitleRepository subtitleRepository,
                       IMapper mapper)
    {
        _filmRepository = filmRepository;
        _film_GenreRepository = film_GenreRepository;
        _film_LanguageRepository = film_LanguageRepository;
        _film_SubtitleRepository = film_SubtitleRepository;
        _film_FormatRepository = film_FormatRepository;
        _formatRepository = formatRepository;
        _languageRepository = languageRepository;
        _subtitleRepository = subtitleRepository;
        _genreRepository = genreRepository;

        _mapper = mapper;
    }



    //? COMPLETE DTOS, ADD MAPPER AND VALIDATOR
    public async Task<List<FilmDTO>> FindAllAsync()
    {
        var films = await _filmRepository.FindByCondition(con => con.IsNew != true)
            .Include(fg => fg.Film_Genres).ThenInclude(g => g.Genre)
            .Include(fl => fl.Film_Languages).ThenInclude(fl => fl.Language)
            .Include(ff => ff.Film_Formats).ThenInclude(ff => ff.Format)
            .Include(fs => fs.Film_Subtitles).ThenInclude(fs => fs.Subtitle)
            .ToListAsync();

        List<FilmDTO> filmDTO = _mapper.Map<List<FilmDTO>>(films);
        return filmDTO;
    }
    public async Task CreateAsync(FilmCreateDTO filmCreateDTO)
    {
        if (filmCreateDTO is null)
        {
            throw new NullReferenceException("Film is null");
        }

        //Maybe there is not genre,lang,subtit,format in this id,check all id
        foreach (var id in filmCreateDTO.Genres_Id)
        {
            var genre = await _genreRepository.FindByIdAsync(id);
            if (genre is null)
            {
                throw new NotFoundException("Not found genre");
            }
        }
        foreach (var id in filmCreateDTO.Languages_Id)
        {
            var language = await _languageRepository.FindByIdAsync(id);
            if (language is null)
            {
                throw new NotFoundException("Not found language");
            }
        }
        foreach (var id in filmCreateDTO.Subtitles_Id)
        {
            var subtitle = await _subtitleRepository.FindByIdAsync(id);
            if (subtitle is null)
            {
                throw new NotFoundException("Not found subtitle");
            }
        }
        foreach (var id in filmCreateDTO.Formats_Id)
        {
            var format = await _formatRepository.FindByIdAsync(id);
            if (format is null)
            {
                throw new NotFoundException("Not found format");
            }
        }


        var film = _mapper.Map<Film>(filmCreateDTO);

        //add film to film table
        await _filmRepository.CreateAsync(film);
        await _filmRepository.SaveChangesAsync();

        //!ADD GENRE
        foreach (var id in filmCreateDTO.Genres_Id)
        {
            Film_Genre film_genre = new()
            {
                Genre_Id = id,
                Film_Id = film.Id
            };
            await _film_GenreRepository.CreateAsync(film_genre);
        }

        //!ADD LANGUAGE
        foreach (var id in filmCreateDTO.Languages_Id)
        {
            Film_Language film_language = new()
            {
                Language_Id = id,
                Film_Id = film.Id
            };
            await _film_LanguageRepository.CreateAsync(film_language);
        }

        //!ADD FORMAT
        foreach (var id in filmCreateDTO.Formats_Id)
        {
            Film_Format film_format = new()
            {
                Format_Id = id,
                Film_Id = film.Id
            };
            await _film_FormatRepository.CreateAsync(film_format);

        }

        //!ADD SUBTITTLE
        foreach (var id in filmCreateDTO.Subtitles_Id)
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
