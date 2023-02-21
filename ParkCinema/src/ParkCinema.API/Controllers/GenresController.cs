using Microsoft.AspNetCore.Mvc;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.DTOs.Genre;
using ParkCinema.Business.Services.Implementations;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Business.Utilities.Exceptions;
using System.Net;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var genres = await _genreService.FindAllAsync();
        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GenreCreateDTO genreCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            await _genreService.CreateAsync(genreCreateDTO);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreById([FromRoute] int id)
    {
        try
        {
            var genre = await _genreService.FindByIdAsync(id);
            return Ok(genre);
        }
        catch (NotFoundException)
        {
            return StatusCode((int)HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            // return BadRequest(ex.Message);  
            throw new Exception(ex.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _genreService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }




}
