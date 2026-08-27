using Book_Store_API.DTOS;
using Book_Store_API.Exceptions;
using Book_Store_API.Models;
using Book_Store_API.Seeding;

namespace Book_Store_API.Services
{
    public class AuthorService : IAuthorService
    {

        public IEnumerable<AuthorResponse> GetAll()
        {
            var Authors = BookSeeding.Authors.ToList();
            var AuthorResponseDTO = Authors.Select(s => new AuthorResponse()
            {

                FullName = s.FullName,
                Country = s.Country,
                BirthDate = s.BirthDate

            }).ToList();

            return AuthorResponseDTO;
        }

        public AuthorResponse Create(CreateAuthorRequest createAuthor)
        {
            if (string.IsNullOrWhiteSpace(createAuthor.FullName))
                throw new BusinessException("Full Name is Required", 400);
            if(string.IsNullOrWhiteSpace(createAuthor.Country))
                throw new BusinessException("Country is Required", 400);

            var Author = BookSeeding.Authors.Find(b => b.FullName.Equals(createAuthor.FullName, StringComparison.OrdinalIgnoreCase));

            if(Author is not null)
                throw new BusinessException("Author Name must be unique", 400);

            var CreateAuthor = new Author()
            {

                Id = BookSeeding.Authors.Any() ? BookSeeding.Authors.Max(s => s.Id) + 1 : 1,
                FullName= createAuthor.FullName,
                BirthDate= createAuthor.BirthDate,
                Country = createAuthor.Country
                
            };

            BookSeeding.Authors.Add(CreateAuthor);

            var CreateAuthorRequestDTO = new AuthorResponse()
            {

                FullName = CreateAuthor.FullName,
                BirthDate = CreateAuthor.BirthDate,
                Country = CreateAuthor.Country
            };

            return CreateAuthorRequestDTO;

        }

       
    }
}
