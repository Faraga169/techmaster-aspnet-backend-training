using Drill_01_DbContext___First_Migration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drill_01_DbContext___First_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(IInstructorService instructorService) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {

            var result=instructorService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}/tracks")]

        public IActionResult GetById(int id) {

            var result = instructorService.GetById(id);
            return Ok(result);

        }
    }

}
