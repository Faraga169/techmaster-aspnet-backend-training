using Book_Store_API.DTOS;
using Book_Store_API.Exceptions;
using Book_Store_API.Models;
using Book_Store_API.Seeding;

namespace Book_Store_API.Services
{
    public class BookService
    {
        public IEnumerable<BookResponse> GetAll(string? Title,string? category,string?author,bool availability=true,int pagesize=5,int pagenumber=1)
        {
            var FilterBooks = BookSeeding.Books.ToList();
            if (!string.IsNullOrWhiteSpace(Title))
                FilterBooks = FilterBooks.Where(b => b.Title.Contains(Title, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrWhiteSpace(category)) {
                var categoryId = BookSeeding.Categories.FirstOrDefault(c => c.Name.Equals(category, StringComparison.OrdinalIgnoreCase))?.Id??throw new BusinessException("Category Not Found",404);
                FilterBooks = FilterBooks.Where(b => b.CategoryId == categoryId).ToList();

            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                var authorId = BookSeeding.Authors.FirstOrDefault(c => c.FullName.Equals(author, StringComparison.OrdinalIgnoreCase))?.Id ?? throw new BusinessException("Author Not Found", 404);
                FilterBooks = FilterBooks.Where(b => b.AuthorId == authorId).ToList();

            }
            FilterBooks = FilterBooks.Where(b => b.IsAvailable == availability).ToList();
            int TotalofBooks = FilterBooks.Count;
            if (pagesize <= 0)
                throw new BusinessException("Page size must be positive", 400);
            int numberofpages = (int)Math.Ceiling((decimal)TotalofBooks / pagesize);
            if (pagenumber<=0)
                throw new BusinessException("Page number must be greater than 0", 400);
            if (pagenumber > numberofpages && numberofpages > 0)
                throw new BusinessException("Page number exceeds total pages", 400);
          
            FilterBooks =FilterBooks.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToList();

            var BooksResponseDTO = FilterBooks.Select(b => new BookResponse()
            {

                Id = b.Id,
                ISBN = b.ISBN,
                Title = b.Title,
                StockQuantity = b.StockQuantity,
                PublishedYear = b.PublishedYear,
                Price = b.Price,
                IsAvailable = b.IsAvailable,
                CategoryName = BookSeeding.Categories.FirstOrDefault(c => c.Id == b.CategoryId)?.Name ?? "Unknown",
                AuthorName= BookSeeding.Authors.FirstOrDefault(c=>c.Id==b.AuthorId)?.FullName?? "Unknown"
            }).ToList();

            return BooksResponseDTO;
        }

        public BookResponse GetById(int Id)
        {
            var book = BookSeeding.Books.Find(p => p.Id == Id);
            if (book is null)
                throw new BusinessException("book is not found", 404);

            var BookResponseDTO = new BookResponse()
            {
                Id = book.Id,
                ISBN =book.ISBN,
                IsAvailable=book.IsAvailable,
                Price=book.Price,
                StockQuantity=book.StockQuantity,
                Title=book.Title,
                PublishedYear=book.PublishedYear,
                CategoryName = BookSeeding.Categories.FirstOrDefault(c => c.Id == book.CategoryId)?.Name ?? "Unknown",
                AuthorName = BookSeeding.Authors.FirstOrDefault(c => c.Id == book.AuthorId)?.FullName ?? "Unknown"
            };

            return BookResponseDTO;
        }

        public BookResponse Add(CreateBookRequest createBookRequest)
        {
            var categoryIdexist = BookSeeding.Categories.FirstOrDefault(c => c.Id == createBookRequest.CategoryId);
            var authorIdexist = BookSeeding.Authors.FirstOrDefault(a => a.Id == createBookRequest.AuthorId);
            var availablecategory = BookSeeding.Categories.FirstOrDefault(c => c.Id == createBookRequest.CategoryId && !c.IsActive);
            if (string.IsNullOrWhiteSpace(createBookRequest.Title))

                throw new BusinessException("Title is Required", 400);


            if (string.IsNullOrWhiteSpace(createBookRequest.ISBN))

                throw new BusinessException("ISBN is Required", 400);

          


            if (createBookRequest.Price < 0)
                throw new BusinessException("Book Price must be positive", 400);

            if (createBookRequest.StockQuantity < 0)
                throw new BusinessException("stockQuantity must be positive", 400);

            if(categoryIdexist is  null)
                throw new BusinessException("Category Not found", 404);

            if (authorIdexist is null)
                throw new BusinessException("Author Not found", 404);

            if(availablecategory is not null)
                throw new BusinessException("Inactive categories cannot be used for new books", 404);
            var existbookname = BookSeeding.Books.Any(c => c.Title.Equals(createBookRequest.Title, StringComparison.OrdinalIgnoreCase));
            var existbookISBN = BookSeeding.Books.Any(c => c.ISBN.Equals(createBookRequest.ISBN, StringComparison.OrdinalIgnoreCase));

            if (existbookname)
                throw new BusinessException("Book Name must be unique", 400);

            if (existbookISBN)
                throw new BusinessException("Book ISBN must be unique", 400);

            var Book = new Book()
            {

                Id = BookSeeding.Books.Any() ? BookSeeding.Books.Max(s => s.Id) + 1 : 1,
                Title = createBookRequest.Title,
                Price = createBookRequest.Price,
                IsAvailable = createBookRequest.IsAvailable,
                StockQuantity = createBookRequest.StockQuantity,
                ISBN = createBookRequest.ISBN,
                PublishedYear= createBookRequest.PublishedYear,
                AuthorId= createBookRequest.AuthorId,
                CategoryId = createBookRequest.CategoryId
            };

            BookSeeding.Books.Add(Book);
           

            var BookResponseDTO = new BookResponse()
            {
                Id = Book.Id,
                Price = Book.Price,
                IsAvailable = Book.IsAvailable,
                StockQuantity = Book.StockQuantity,
                ISBN= Book.ISBN,
                PublishedYear = Book.PublishedYear,
                Title= Book.Title,
                CategoryName = BookSeeding.Categories.FirstOrDefault(c => c.Id == Book.CategoryId)?.Name ?? "Unknown",
                AuthorName = BookSeeding.Authors.FirstOrDefault(c => c.Id == Book.AuthorId)?.FullName ?? "Unknown"
            };

            return BookResponseDTO;
        }


        public BookResponse Update(int Id, UpdateBookRequest updateBookRequest)
        {
            var categoryIdexist = BookSeeding.Categories.FirstOrDefault(c => c.Id == updateBookRequest.CategoryId);
            var authorIdexist = BookSeeding.Authors.FirstOrDefault(a => a.Id == updateBookRequest.AuthorId);
            var availablecategory = BookSeeding.Categories.FirstOrDefault(c => c.Id == updateBookRequest.CategoryId && !c.IsActive);
            var Book = BookSeeding.Books.FirstOrDefault(b => b.Id == Id);
            if (string.IsNullOrWhiteSpace(updateBookRequest.Title))

                throw new BusinessException("Title is Required", 400);


            if (string.IsNullOrWhiteSpace(updateBookRequest.ISBN))

                throw new BusinessException("ISBN is Required", 400);




            if (updateBookRequest.Price < 0)
                throw new BusinessException("Book Price must be positive", 400);

            if (updateBookRequest.StockQuantity < 0)
                throw new BusinessException("stockQuantity must be positive", 400);
            
            if(Book is null)
                throw new BusinessException("Book Not found", 404);

            if (categoryIdexist is null)
                throw new BusinessException("Category Not found", 404);

            if (authorIdexist is null)
                throw new BusinessException("Author Not found", 404);

            if (availablecategory is not null)
                throw new BusinessException("Inactive categories cannot be used for new books", 404);

            var existbookname = BookSeeding.Books.Find(c => c.Title.Equals(updateBookRequest.Title, StringComparison.OrdinalIgnoreCase)&&c.Id!=Id);
            var existbookISBN = BookSeeding.Books.Find(c => c.ISBN.Equals(updateBookRequest.ISBN, StringComparison.OrdinalIgnoreCase)&&c.Id!=Id);
            
            if (existbookname is not null)
                throw new BusinessException("Book Name must be unique", 400);

            if (existbookISBN is not null)
                throw new BusinessException("Book ISBN must be unique", 400);





            Book.Title = updateBookRequest.Title;
            Book.Price = updateBookRequest.Price;
            Book.IsAvailable = updateBookRequest.IsAvailable;
            Book.StockQuantity = updateBookRequest.StockQuantity;
            Book.ISBN = updateBookRequest.ISBN;
            Book.PublishedYear = updateBookRequest.PublishedYear;
            Book.AuthorId = updateBookRequest.AuthorId;
            Book.CategoryId = updateBookRequest.CategoryId;
           

         


            var BookResponseDTO = new BookResponse()
            {
                Id = Book.Id,
                Price = Book.Price,
                IsAvailable = Book.IsAvailable,
                StockQuantity = Book.StockQuantity,
                ISBN = Book.ISBN,
                PublishedYear = Book.PublishedYear,
                Title = Book.Title,
                CategoryName = BookSeeding.Categories.FirstOrDefault(c => c.Id == Book.CategoryId)?.Name ?? "Unknown",
                AuthorName = BookSeeding.Authors.FirstOrDefault(c => c.Id == Book.AuthorId)?.FullName ?? "Unknown"
            };

            return BookResponseDTO;
        }


        public void Delete(int Id)
        {
            var Book = BookSeeding.Books.Find(c => c.Id == Id);
            if (Book is null)
                throw new BusinessException("Book is not found", 404);

            BookSeeding.Books.Remove(Book);
        }



        public StockReportResponse StockReport()
        {

            var stockReport = BookSeeding.Books.ToList();

            var totalbooks = stockReport.Count();

            var bookspercategory = stockReport.GroupBy(s => s.CategoryId).Select(g => {

                var category = BookSeeding.Categories.FirstOrDefault(c => c.Id == g.Key);

                return new booksperCategoryResponse { CategoryName = category?.Name ?? "unknown", Count = g.Count() };

            }).ToList();



            var AvailableBooks = stockReport.Where(s => s.IsAvailable).Select(s => new BookResponse()
            {

                Id = s.Id,
                Price = s.Price,
                IsAvailable = s.IsAvailable,
                StockQuantity = s.StockQuantity,
                ISBN = s.ISBN,
                PublishedYear = s.PublishedYear,
                Title = s.Title,
                CategoryName = BookSeeding.Categories.FirstOrDefault(c => c.Id == s.CategoryId)?.Name ?? "Unknown",
                AuthorName = BookSeeding.Authors.FirstOrDefault(c => c.Id == s.AuthorId)?.FullName ?? "Unknown"

            }).ToList();

            var outstockbooks = stockReport.Where(s => s.StockQuantity == 0).Select(s => new BookResponse()
            {

                Id = s.Id,
                Price = s.Price,
                IsAvailable = s.IsAvailable,
                StockQuantity = s.StockQuantity,
                ISBN = s.ISBN,
                PublishedYear = s.PublishedYear,
                Title = s.Title,
                CategoryName = BookSeeding.Categories.FirstOrDefault(c => c.Id == s.CategoryId)?.Name ?? "Unknown",
                AuthorName = BookSeeding.Authors.FirstOrDefault(c => c.Id == s.AuthorId)?.FullName ?? "Unknown"

            }).ToList();


            var booksperAuthor = stockReport.GroupBy(s => s.AuthorId).Select(g => {

                var Author = BookSeeding.Authors.FirstOrDefault(c => c.Id == g.Key);

                return new booksperAuthorResponse {  AuthorName= Author?.FullName ?? "unknown", Count = g.Count() };

            }).ToList();


            var TotalInventory = stockReport.Sum(s => s.StockQuantity * s.Price);

            var stockreportResponse = new StockReportResponse()
            {
                TotalBooks=totalbooks,
                AvailableBooks=AvailableBooks,
                OutStockBooks=outstockbooks,
                TotalBooksPerCategory=bookspercategory,
                TotalBooksPerAuthor=booksperAuthor,
                TotalInventoryValue=TotalInventory
               
            };

            return stockreportResponse;
        }
    }
}
