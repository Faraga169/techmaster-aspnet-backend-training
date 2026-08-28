using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_06_api_standards_refactor_pack.RefactoredAPI.DTOS;
using task_06_api_standards_refactor_pack.RefactoredAPI.Services;

namespace task_06_api_standards_refactor_pack.RefactoredAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            var products = productService.GetAll();

            return Ok(products);

        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            var product = productService.GetById(id);

            return Ok(product);

        }

        [HttpPost]
        public IActionResult Create(CreateProductRequest createProduct)
        {

            var productCreate = productService.Create(createProduct);

            return CreatedAtAction(nameof(GetById), new { id = productCreate.Id }, productCreate);

        }
    }
}
