using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.User.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.User.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Dictionary<int, string>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        Dictionary<int, string> genres = GenreExtensions
            .GetValues()
            .Cast<Genre>()
            .ToDictionary(x => (int)x, x => x.ToString());
        return Ok(genres);
    }
}
