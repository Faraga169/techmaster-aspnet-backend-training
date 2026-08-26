using System.ComponentModel.DataAnnotations;

namespace Products_CategoriesAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description{ get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
