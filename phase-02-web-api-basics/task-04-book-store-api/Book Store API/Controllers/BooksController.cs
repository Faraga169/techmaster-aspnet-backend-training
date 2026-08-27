using Book_Store_API.DTOS;
using Book_Store_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? Title, string? category, string? author, bool availability = true, int pagesize = 5, int pagenumber = 1)
        {

            var Books = bookService.GetAll(Title,category, author, availability, pagesize, pagenumber);

            return Ok(Books);

        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            var book = bookService.GetById(id);

            return Ok(book);

        }

        [HttpPost]
        public IActionResult Create(CreateBookRequest createBook)
        {

            var bookCreate = bookService.Add(createBook);

            return CreatedAtAction(nameof(GetById), new { id = bookCreate.Id }, bookCreate);

        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, UpdateBookRequest updateBook)
        {

            var bookUpdate = bookService.Update(Id, updateBook);

            return Ok(bookUpdate);

        }




        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            bookService.Delete(id);

            return NoContent();

        }


        [HttpGet("reports/summary")]
        public IActionResult Report()
        {
            var books = bookService.StockReport();
            return Ok(books);
        }
    }
}
