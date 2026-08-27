using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.DTOS
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public string Country { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

    }
}
