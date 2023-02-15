using Microsoft.AspNetCore.Mvc;
using ParkCinema.Business.DTOs.Film;
using ParkCinema.Business.Services.Interfaces;
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
    public async Task<IActionResult> Get()
    {
        var films = await _filmService.FindAllAsync();
        return Ok(films);
    }

    [HttpPost]
    public async Task<IActionResult> Post(FilmCreateDTO createDTO)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        }
        await _filmService.CreateAsync(createDTO);
        return StatusCode((int)HttpStatusCode.Created);

    }


}
