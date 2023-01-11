using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private ICollection<Movie> Movies = new List<Movie>()
        {
            new Movie(1, "Fight Club", 1999),
            new Movie(2, "Seven", 1995),
            new Movie(3, "Good Time", 2017),
            new Movie(4, "Drive", 2011),
            new Movie(5, "Whiplash", 2014),
            new Movie(6, "The Departed", 2006)
        };

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> Get()
        {
            return Movies;
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            Movies.Remove(movie);

            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {          
            if (movie == null)
                return BadRequest();

            Movies.Add(movie);

            return Ok();
        }
    }

    public class Movie
    {
        public Movie(int id, string name, int year)
        {
            Id = id;
            Name = name;
            Year = year;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
