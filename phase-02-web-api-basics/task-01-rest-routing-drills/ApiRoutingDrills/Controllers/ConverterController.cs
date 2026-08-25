using ApiRoutingDrills.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController(ConverterService converterService) : ControllerBase
    {
        

        [HttpGet("celsius-to-fahrenheit")]
        public IActionResult Convert(decimal? value)
        {
            if(value is null)

                return BadRequest(new { message = "value was not provided" });


           
            return Ok(new { formulaUsed= "(C × 9/5) + 32", celesius=value,fahrenheit = converterService.ConvertCelsiusToFahrenheit(value.Value)});

        }
    }
}
