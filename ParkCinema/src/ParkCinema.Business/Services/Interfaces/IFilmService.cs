using ParkCinema.Business.DTOs.Film;
using ParkCinema.Core.Entities;
using System.Linq.Expressions;

namespace ParkCinema.Business.Services.Interfaces;

public interface IFilmService
{
    Task<List<FilmDTO>> FindAllAsync();
    Task CreateAsync(FilmCreateDTO filmDTO);
    
    //Task<List<FilmDTO>> FindByConditionAsync(Expression<Func<Film, bool>> expression);
    //Task<CreateFilmDTO> FindByIdAsync(int id);
    //Task UpdateAsync(int id, CourseUpdateDto courseUpdateDto);
    //Task DeleteAsync(int id);

}
 