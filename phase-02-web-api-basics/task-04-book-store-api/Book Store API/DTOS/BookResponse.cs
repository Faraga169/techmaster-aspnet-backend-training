using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.DTOS
{
    public class BookResponse
    {
        public int Id { get; set; }

       
        public string Title { get; set; } = null!;

       
        public string ISBN { get; set; } = null!;

        public int PublishedYear { get; set; }

      
        public decimal Price { get; set; }

       
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }


        public string AuthorName { get; set; } = null!;

        public string CategoryName { get; set; } = null!;
    }
}
