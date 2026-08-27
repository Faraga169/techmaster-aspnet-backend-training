using Book_Store_API.DTOS;

namespace Book_Store_API.Services
{
    public interface IBookService
    {
        IEnumerable<BookResponse> GetAll(string? Title, string? category,string? author, bool availability = true,int pagesize = 5, int pagenumber = 1);

        BookResponse GetById(int Id);

        BookResponse Add(CreateBookRequest createBookRequest);

        BookResponse Update(int Id, UpdateBookRequest updateBookRequest);

        void Delete(int Id);

        StockReportResponse StockReport();
    }
}
