using Book_Store_API.DTOS;

namespace Book_Store_API.Services
{
    public interface IAuthorService
    {
        public IEnumerable<AuthorResponse> GetAll();

        public AuthorResponse Create(CreateAuthorRequest createAuthor);

        public void Delete(int id);
    }
}
