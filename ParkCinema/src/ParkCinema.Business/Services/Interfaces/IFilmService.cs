using ParkCinema.Business.DTOs.Film;

namespace ParkCinema.Business.Services.Interfaces;

public interface IFilmService
{
    Task<List<FilmDTO>> FindAllAsync();
    Task CreateAsync(FilmCreateDTO filmDTO);
    
    
    //Task<CreateFilmDTO> FindByIdAsync(int id);
    //Task<List<CourseDTO>> FindByConditionAsync(Expression<Func<Course, bool>> expression);
    //Task UpdateAsync(int id, CourseUpdateDto courseUpdateDto);
    //Task DeleteAsync(int id);

}
