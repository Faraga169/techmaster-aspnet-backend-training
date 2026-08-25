using System.ComponentModel.DataAnnotations;

namespace Products_CategoriesAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        public string Name { get; set; } = null!;

        [Range(50,5000,ErrorMessage ="Product price must be in range 50 to 5000")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }


        [Required(ErrorMessage = "SupplierName is Required")]
        public string SupplierName { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Category Category { get; set; } = null!;

        public Guid CategoryId { get; set; }
    }
}
