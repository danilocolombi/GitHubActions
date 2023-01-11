using Microsoft.AspNetCore.Mvc;

namespace GitHubActions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private ICollection<Series> Series = new List<Series>()
       {
            new Series(1, "House of The Dragon", 2022),
            new Series(2, "Andor", 2022),
            new Series(3, "The Bear", 2022),
            new Series(4, "Severance", 2022),
            new Series(5, "Breaking Bad", 2008),
            new Series(6, "How I Met Your Mother", 2005),
            new Series(7, "Peaky Blinders", 2013)
        };

        [HttpGet(Name = "GetSeries")]
        public IEnumerable<Series> Get()
        {
            return Series;
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var series = Series.FirstOrDefault(m => m.Id == id);

            if (series == null)
                return NotFound();

            Series.Remove(series);

            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Series series)
        {
            if (series == null)
                return BadRequest();

            Series.Add(series);

            return Ok();
        }
    }

    public class Series
    {
        public Series(int id, string name, int year)
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
