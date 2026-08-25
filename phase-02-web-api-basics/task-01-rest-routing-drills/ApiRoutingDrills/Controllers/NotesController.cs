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


        [HttpGet("{id?}")]
        public IActionResult GetById(Guid? id) {

            if (id is null)
                return BadRequest(new {Message= "id is not provided" });

            var note = creatednotes.CreateNotes.Find(n => n.Id == id.Value);

            if(note is null)
                return NotFound(new { message = "Note not found" });

            return Ok(note);
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
            return CreatedAtAction(nameof(GetById),new { id=note.Id},note);

        }


        [HttpPut("{id}")]
        public IActionResult Update(Guid? id,UpdateNoteRequest createNote)
        {
            if (string.IsNullOrWhiteSpace(createNote.Title))
                return BadRequest(new { Message = "Title is Required" });

            if (string.IsNullOrWhiteSpace(createNote.Content))
                return BadRequest(new { Message = "Content is Required" });



            var note = creatednotes.CreateNotes.Find(n => n.Id == id);
            if(note is null)

                return NotFound(new { message = "Note not found" });


            note.Title = createNote.Title;
            note.Content = createNote.Content;


            return Ok(note);

        }

    }
}
