using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Calculator(decimal a, decimal? b)
        {
            if (b is null) {

                return BadRequest(new { message = "b was not provided" });
            }
              
            decimal? Sum = a + b;
            return Ok(new { a=a,b=b,operation="Addition",result = Sum });

        }
    }
}
