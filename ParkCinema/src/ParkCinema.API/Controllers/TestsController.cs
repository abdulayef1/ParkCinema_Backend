using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Core.Entities;
using ParkCinema.DataAccess.Interfaces;
using System.Text.Json;

namespace ParkCinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IQRCodeService _qRCodeService;

        public TestsController(IQRCodeService qRCodeService)
        {
            _qRCodeService = qRCodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(bool isNew = false)
        {
            Film film= new Film();
            film.Name = "Avatar";
            film.AgeLimit = 10;
            film.Country = "osirdfhrsuad";
            film.Director = "oauiefhuisaedfh";

          
            string json = JsonSerializer.Serialize(film);
             var res=_qRCodeService.GenerateQRCode(json);
            return File(res,"image/png");
        }



    }
}
