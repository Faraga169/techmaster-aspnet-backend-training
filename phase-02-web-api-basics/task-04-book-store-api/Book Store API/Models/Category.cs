using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public bool IsActive{ get; set; }
    }
}
