using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        [HttpGet("calculate")]
        public IActionResult Calculator(decimal? score)
        {
            string Result;
            string status;
            if (score is null)
            {

                return BadRequest(new { message = "score was not provided" });
            }

            if (score < 0 || score > 100) {

                return BadRequest(new { error = "Score must be between 0 and 100" });
            }

            if (score <= 100 && score >= 90)
            {

                Result="Grade A";
                status = "Pass";
            }

            else if (score <= 89 && score >= 80)
            {

                Result="Grade B";
                status = "Pass";
            }

            else if (score <= 79 && score >= 70)
            {

                Result="Grade C";
                status = "Pass";
            }

            else if (score <= 69 && score >= 60)
            {

                Result="Grade D";
                status = "Pass";
            }

            else
            {

                Result="Grade F";
                status = "Fail";
            }

            return Ok(new { score=score, Grade=Result,Status=status});

        }
    }
}
