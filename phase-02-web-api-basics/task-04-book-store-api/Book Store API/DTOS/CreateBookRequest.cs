using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.DTOS
{
    public class CreateBookRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book Title is Required")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Book ISBN is Required")]
        [StringLength(17, ErrorMessage = "ISBN cannot exceed 17 characters")]
        public string ISBN { get; set; } = null!;

        [Range(1000, 2100, ErrorMessage = "Invalid published year")]
        public int PublishedYear { get; set; }

        [Range(50, 1000000, ErrorMessage = "Price must be between 50 and 1000000")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
    }
}
