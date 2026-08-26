using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_CategoriesAPI.DTOS;
using Products_CategoriesAPI.Services;

namespace Products_CategoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            var categories = categoryService.GetAll();

            return Ok(categories);

        }


        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {

            var category = categoryService.GetById(id);

            return Ok(category);

        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequest createCategory)
        {

            var categoryCreate = categoryService.Add(createCategory);

            return CreatedAtAction(nameof(GetById), new { id = categoryCreate.Id }, categoryCreate);

        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, UpdateCategoryRequest updateCategory)
        {

            var categoryUpdate = categoryService.Update(Id, updateCategory);

            return Ok(categoryUpdate);

        }

      


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            categoryService.Delete(id);

            return NoContent();

        }
    }
}
