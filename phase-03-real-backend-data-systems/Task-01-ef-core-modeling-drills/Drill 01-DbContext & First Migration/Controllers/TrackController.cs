using Drill_01_DbContext___First_Migration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drill_01_DbContext___First_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController(ITrackService trackService) : ControllerBase
    {
        [HttpGet("{id}/students")]

        public IActionResult GetById(int id)
        {

            var result = trackService.GetById(id);
            return Ok(result);

        }
    }
}
