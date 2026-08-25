using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestinfoController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get() {

            var studentName=Request.Headers["X-Student-Name"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(studentName))
                return BadRequest(new { Message = "Student Name is not provide" });

            return Ok(new { studentName = studentName, path = Request.Path });

        }
    }
}
