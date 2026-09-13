using Drill_01_DbContext___First_Migration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drill_01_DbContext___First_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController(IEnrollmentService enrollmentService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(int pagesize=5,int pagenumber=1)
        {

            var result = enrollmentService.GetAll(pagesize,pagenumber);
            return Ok(result);

        }
    }
}
