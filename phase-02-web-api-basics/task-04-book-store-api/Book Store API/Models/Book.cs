using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

      
        public string ISBN { get; set; } = null!;

     
        public int PublishedYear { get; set; }

    
        public decimal Price { get; set; }

      
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

    }
}
