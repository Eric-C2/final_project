using Microsoft.AspNetCore.Mvc;
using final_project.Models;
using final_project.Data;
using final_project.Interfaces;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGameController : ControllerBase
    {
        public required VideoGameContextDAO _context;

        public VideoGameController(VideoGameContextDAO context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int? id)
        {
            if (id is null or 0)
                return Ok(_context.First5VideoGames());

            var result = _context.GetVideoGame(id);

            if (result == null)
                return NotFound(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(VideoGame game)
        {
            var result = _context.AddVideoGame(game);

            if (result == null)
                return StatusCode(500, "Video game already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request.");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.DeleteVideoGame(id);

            if (result == null)
                return NotFound();

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request.");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(VideoGame game)
        {
            var result = _context.UpdateVideoGame(game);

            if (result == null)
                return NotFound(game.Id);

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }

        [HttpPatch]
        public IActionResult Update(VideoGame game)
        {
            var result = _context.UpdateVideoGame(game);

            if (result == null)
                return NotFound(game.Id);

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}
