using System.ComponentModel.DataAnnotations;

namespace ApiRoutingDrills.DTOS
{
    public class UpdateNoteRequest
    {
        public string? Title { get; set; } = null!;

        public string? Content { get; set; } = null!;
    }
}
