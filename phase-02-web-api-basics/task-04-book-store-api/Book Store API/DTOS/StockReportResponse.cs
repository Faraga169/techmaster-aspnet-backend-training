using Book_Store_API.DTOS;

namespace Book_Store_API.DTOS
{
    public class StockReportResponse
    {
        public int TotalBooks { get; set; }

        public List<BookResponse> AvailableBooks { get; set; }=new List<BookResponse>();

        public List<booksperCategoryResponse> TotalBooksPerCategory { get; set; }=new List<booksperCategoryResponse>();

        public List<booksperAuthorResponse> TotalBooksPerAuthor { get; set; } = new List<booksperAuthorResponse>();

        public decimal  TotalInventoryValue{ get; set; }

        public List<BookResponse> OutStockBooks { get; set; } = new List<BookResponse>();

        

    }
}
