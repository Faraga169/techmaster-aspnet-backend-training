using Book_Store_API.DTOS;
using Book_Store_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            var Categories = categoryService.GetAll();
            return Ok(Categories);

        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequest createCategoryRequest)
        {

            var Category = categoryService.Create(createCategoryRequest);
            return Ok(Category);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            categoryService.Delete(id);
            return NoContent();
        }
    }
}
