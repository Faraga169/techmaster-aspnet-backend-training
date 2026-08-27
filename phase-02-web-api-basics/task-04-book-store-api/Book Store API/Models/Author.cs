using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Author Name is Required")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Author Country is Required")]
        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string Country { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
