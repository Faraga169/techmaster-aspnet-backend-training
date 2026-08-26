using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_CategoriesAPI.DTOS;
using Products_CategoriesAPI.Services;

namespace Products_CategoriesAPI.Controllers
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


        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {

            var product = productService.GetById(id);

            return Ok(product);

        }

        [HttpPost]
        public IActionResult Create(CreateProductRequest createProduct)
        {

            var productCreate = productService.Add(createProduct);

            return CreatedAtAction(nameof(GetById), new { id = productCreate.Id }, productCreate);

        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, UpdateProductRequest updateProduct)
        {

            var productUpdate = productService.Update(Id, updateProduct);

            return Ok(productUpdate);

        }




        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            productService.Delete(id);

            return NoContent();

        }
    }
}
