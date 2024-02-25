using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        string[] genres = Enum.GetNames(typeof(Genre));
        return Ok(genres);
    }
}
