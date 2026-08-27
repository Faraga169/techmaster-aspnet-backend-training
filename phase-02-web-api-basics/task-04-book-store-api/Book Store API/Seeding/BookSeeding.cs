using Book_Store_API.Models;

namespace Book_Store_API.Seeding
{
    public static class BookSeeding
    {
        public static List<Category> Categories { get; } = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Programming",
                Description = "Programming and software development books",
                IsActive = true
            },

            new Category
            {
                Id = 2,
                Name = "Database",
                Description = "Database design and management books",
                IsActive = true
            },

            new Category
            {
                Id = 3,
                Name = "Computer Science",
                Description = "Computer science and algorithms books",
                IsActive = true
            },

            new Category
            {
                Id = 4,
                Name = "Technology",
                Description = "General technology and modern computing books",
                IsActive = true
            },

            new Category
            {
                Id = 5,
                Name = "Business",
                Description = "Business and entrepreneurship books",
                IsActive = false
            }
        };

        public static List<Author> Authors { get; } = new List<Author>
        {
            new Author
            {
                Id = 1,
                FullName = "Robert C. Martin",
                Country = "United States",
                BirthDate = new DateOnly(1952, 12, 5)
            },

            new Author
            {
                Id = 2,
                FullName = "Martin Fowler",
                Country = "United Kingdom",
                BirthDate = new DateOnly(1963, 12, 18)
            },

            new Author
            {
                Id = 3,
                FullName = "Andrew S. Tanenbaum",
                Country = "United States",
                BirthDate = new DateOnly(1944, 3, 16)
            },

            new Author
            {
                Id = 4,
                FullName = "Thomas H. Cormen",
                Country = "United States",
                BirthDate = new DateOnly(1956, 6, 22)
            },

            new Author
            {
                Id = 5,
                FullName = "Eric Evans",
                Country = "United States",
                BirthDate = new DateOnly(1960, 1, 1)
            }
        };

        public static List<Book> Books { get; } = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                ISBN = "9780132350884",
                PublishedYear = 2008,
                Price = 850,
                StockQuantity = 10,
                IsAvailable = true,
                AuthorId = 1,
                CategoryId = 1
            },

            new Book
            {
                Id = 2,
                Title = "Clean Architecture",
                ISBN = "9780134494166",
                PublishedYear = 2017,
                Price = 950,
                StockQuantity = 7,
                IsAvailable = true,
                AuthorId = 1,
                CategoryId = 1
            },

            new Book
            {
                Id = 3,
                Title = "The Clean Coder",
                ISBN = "9780137081073",
                PublishedYear = 2011,
                Price = 750,
                StockQuantity = 4,
                IsAvailable = true,
                AuthorId = 1,
                CategoryId = 1
            },

            new Book
            {
                Id = 4,
                Title = "Refactoring",
                ISBN = "9780134757599",
                PublishedYear = 2018,
                Price = 1200,
                StockQuantity = 8,
                IsAvailable = true,
                AuthorId = 2,
                CategoryId = 1
            },

            new Book
            {
                Id = 5,
                Title = "Patterns of Enterprise Application Architecture",
                ISBN = "9780321127426",
                PublishedYear = 2002,
                Price = 1400,
                StockQuantity = 3,
                IsAvailable = true,
                AuthorId = 2,
                CategoryId = 1
            },

            new Book
            {
                Id = 6,
                Title = "Domain-Driven Design",
                ISBN = "9780321125217",
                PublishedYear = 2003,
                Price = 1300,
                StockQuantity = 6,
                IsAvailable = true,
                AuthorId = 5,
                CategoryId = 1
            },

            new Book
            {
                Id = 7,
                Title = "Introduction to Algorithms",
                ISBN = "9780262046305",
                PublishedYear = 2022,
                Price = 1600,
                StockQuantity = 5,
                IsAvailable = true,
                AuthorId = 4,
                CategoryId = 3
            },

            new Book
            {
                Id = 8,
                Title = "Algorithms Unlocked",
                ISBN = "9780262518802",
                PublishedYear = 2013,
                Price = 700,
                StockQuantity = 12,
                IsAvailable = true,
                AuthorId = 4,
                CategoryId = 3
            },

            new Book
            {
                Id = 9,
                Title = "Operating System Concepts",
                ISBN = "9781119800361",
                PublishedYear = 2021,
                Price = 1100,
                StockQuantity = 9,
                IsAvailable = true,
                AuthorId = 3,
                CategoryId = 3
            },

            new Book
            {
                Id = 10,
                Title = "Modern Operating Systems",
                ISBN = "9780137618873",
                PublishedYear = 2022,
                Price = 1250,
                StockQuantity = 4,
                IsAvailable = true,
                AuthorId = 3,
                CategoryId = 3
            },

            new Book
            {
                Id = 11,
                Title = "Computer Networks",
                ISBN = "9780132126953",
                PublishedYear = 2010,
                Price = 1000,
                StockQuantity = 15,
                IsAvailable = true,
                AuthorId = 3,
                CategoryId = 4
            },

            new Book
            {
                Id = 12,
                Title = "Database System Concepts",
                ISBN = "9780078022159",
                PublishedYear = 2019,
                Price = 1150,
                StockQuantity = 6,
                IsAvailable = true,
                AuthorId = 3,
                CategoryId = 2
            },

            new Book
            {
                Id = 13,
                Title = "Fundamentals of Database Systems",
                ISBN = "9780133970777",
                PublishedYear = 2016,
                Price = 1050,
                StockQuantity = 2,
                IsAvailable = true,
                AuthorId = 3,
                CategoryId = 2
            },

            new Book
            {
                Id = 14,
                Title = "SQL Performance Explained",
                ISBN = "9783950307825",
                PublishedYear = 2012,
                Price = 900,
                StockQuantity = 0,
                IsAvailable = false,
                AuthorId = 2,
                CategoryId = 2
            },

            new Book
            {
                Id = 15,
                Title = "Effective Java",
                ISBN = "9780134685991",
                PublishedYear = 2018,
                Price = 1000,
                StockQuantity = 11,
                IsAvailable = true,
                AuthorId = 2,
                CategoryId = 1
            },

            new Book
            {
                Id = 16,
                Title = "The Pragmatic Programmer",
                ISBN = "9780135957059",
                PublishedYear = 2019,
                Price = 950,
                StockQuantity = 5,
                IsAvailable = true,
                AuthorId = 2,
                CategoryId = 1
            },

            new Book
            {
                Id = 17,
                Title = "Design Patterns",
                ISBN = "9780201633610",
                PublishedYear = 1994,
                Price = 1350,
                StockQuantity = 3,
                IsAvailable = true,
                AuthorId = 2,
                CategoryId = 1
            },

            new Book
            {
                Id = 18,
                Title = "Technology Strategy",
                ISBN = "9781234567897",
                PublishedYear = 2023,
                Price = 650,
                StockQuantity = 20,
                IsAvailable = true,
                AuthorId = 5,
                CategoryId = 4
            }
        };
    }
}
