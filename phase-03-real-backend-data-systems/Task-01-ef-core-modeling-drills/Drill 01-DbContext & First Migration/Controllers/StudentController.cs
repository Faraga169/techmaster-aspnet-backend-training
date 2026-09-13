using Drill_01_DbContext___First_Migration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drill_01_DbContext___First_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpGet("{id}/tracks")]

        public IActionResult GetById(int id)
        {

            var result = studentService.GetById(id);
            return Ok(result);

        }
    }
}
