using System.ComponentModel.DataAnnotations;

namespace Products_CategoriesAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="CategoryName is Required")]
        public string Name { get; set; } = null!;

        [StringLength(100,ErrorMessage ="Description characters must be less than 100")]
        public string? Description{ get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
