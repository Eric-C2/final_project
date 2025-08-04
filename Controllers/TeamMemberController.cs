using Microsoft.AspNetCore.Mvc;
using final_project.Models;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class TeamMemberController : ControllerBase
    {
        private readonly ILogger<TeamMemberController> _logger;

        public TeamMemberController(ILogger<TeamMemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
