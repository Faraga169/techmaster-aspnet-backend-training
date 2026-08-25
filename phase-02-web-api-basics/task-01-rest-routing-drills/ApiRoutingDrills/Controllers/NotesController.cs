using ApiRoutingDrills.DTOS;
using ApiRoutingDrills.Models;
using ApiRoutingDrills.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController(Creatednotes creatednotes) : ControllerBase
    {

        [HttpGet]

        public IActionResult GetAll()
        {
            var notes = creatednotes.CreateNotes.ToList();
            return Ok(notes);
        }


        [HttpPost]
        public IActionResult Create(CreateNoteRequest createNote) {

            if (createNote is null)
                return BadRequest();
            var note = new Notes
            {
                Id = Guid.NewGuid(),
                Title = createNote.Title,
                Content = createNote.Content,
                CreatedAt = DateTime.UtcNow
            };
            creatednotes.CreateNotes.Add(note);
            return Ok(note);

        }
    }
}
