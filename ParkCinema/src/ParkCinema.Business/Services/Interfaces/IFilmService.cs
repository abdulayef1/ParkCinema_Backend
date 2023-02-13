using ParkCinema.Business.DTOs.Film;
using ParkCinema.Core.Entities;
using System.Linq.Expressions;

namespace ParkCinema.Business.Services.Interfaces;

public interface IFilmService
{
    Task<List<FilmDTO>> FindAllAsync();


    //Task<CourseDTO> FindByIdAsync(int id);
    //Task<List<CourseDTO>> FindByConditionAsync(Expression<Func<Course, bool>> expression);
    //Task CreateAsync(CoursePostDto entity);
    //Task UpdateAsync(int id, CourseUpdateDto courseUpdateDto);
    //Task DeleteAsync(int id);

}
