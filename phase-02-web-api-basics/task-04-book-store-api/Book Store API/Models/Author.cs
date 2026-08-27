using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.Models
{
    public class Author
    {
        public int Id { get; set; }
     
        public string FullName { get; set; } = null!;
     
        public string Country { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
    }
}
