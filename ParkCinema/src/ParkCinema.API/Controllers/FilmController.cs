using Microsoft.AspNetCore.Mvc;
using ParkCinema.Business.Services.Interfaces;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{

    private readonly IFilmService _filmService;

    public FilmController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var films=await _filmService.FindAllAsync();
        return Ok(films);
    }

}
