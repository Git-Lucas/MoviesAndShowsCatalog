using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        IEnumerable<string> genres = Enum
            .GetValues(typeof(Genre))
            .Cast<Genre>()
            .Select(x => x.ToString());

        return Ok(genres);
    }
}
