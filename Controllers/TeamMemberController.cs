using Microsoft.AspNetCore.Mvc;
using final_project.Models;
using final_project.Data;
using final_project.Controllers;
using System.Runtime.InteropServices;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase
    {

        public required TeamMemberContextDAO _context;

        public TeamMemberController(TeamMemberContextDAO context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int? id)
        {
            if (id is null or 0)
                return Ok(_context.First5Members());

            var result = _context.GetTeamMember(id);

            if (result == null)
                return NotFound(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(TeamMember member)
        {
            var result = _context.AddTeamMember(member);

            if (result == null)
                return StatusCode(500, "Member already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request.");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.DeleteTeamMember(id);

            if (result == null)
                return NotFound();

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request.");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(TeamMember member) 
        {
            var result = _context.UpdateTeamMember(member);

            if (result == null)
                return NotFound(member.Id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPatch]
        public IActionResult Update(TeamMember member) 
        {
            var result = _context.UpdateTeamMember(member);

            if (result == null)
                return NotFound(member.Id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }
    }
}
