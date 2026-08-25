using System.ComponentModel.DataAnnotations;

namespace ApiRoutingDrills.DTOS
{
    public class CreateNoteRequest
    {

        [Required]
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

    }
}
