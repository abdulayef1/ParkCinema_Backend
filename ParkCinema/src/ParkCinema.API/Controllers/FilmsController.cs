using Microsoft.AspNetCore.Mvc;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Interfaces;
using ParkCinema.Business.Utilities.Exceptions;
using System.Net;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmsController : ControllerBase
{

    private readonly IFilmService _filmService;

    public FilmsController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var films = await _filmService.FindAllAsync();
        return Ok(films);
    }



    [HttpPost]
    public async Task<IActionResult> Post([FromForm] FilmCreateDTO filmCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            await _filmService.CreateAsync(filmCreateDTO);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFilmById([FromRoute] int id)
    {
        try
        {
            var film = await _filmService.FindByIdAsync(id);
            return Ok(film);
        }
        catch (Exception ex)
        {
           // return BadRequest(ex.Message);  
           throw new Exception(ex.Message);
        }
    }

    //?Complete these controllers

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _filmService.DeleteAsync(id);
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

    [HttpPut]
    public async Task<IActionResult> Update(int id,[FromForm] FilmUpdateDTO filmUpdateDTO)
    {
        try
        {
            await _filmService.UpdateAsync(id, filmUpdateDTO);
            return Ok();
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
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
