using Book_Store_API.DTOS;
using Book_Store_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IAuthorService authorService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {

            var Authors = authorService.GetAll();
            return Ok(Authors);

        }

        [HttpPost]
        public IActionResult Create(CreateAuthorRequest createAuthorRequest) { 
        
            var Author=authorService.Create(createAuthorRequest);
            return Ok(Author);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            authorService.Delete(id);
            return NoContent();
        }

    }
}
