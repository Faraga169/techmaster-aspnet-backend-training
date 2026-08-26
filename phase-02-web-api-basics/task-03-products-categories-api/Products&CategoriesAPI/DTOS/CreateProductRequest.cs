using System.ComponentModel.DataAnnotations;
using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.DTOS
{
    public class CreateProductRequest
    {
       

        [Required(ErrorMessage = "Product Name is Required")]
        public string Name { get; set; } = null!;

        [Range(50, 5000, ErrorMessage = "Product price must be in range 50 to 5000")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }


        [Required(ErrorMessage = "SupplierName is Required")]
        public string SupplierName { get; set; } = null!;

        public Guid? CategoryId { get; set; }
    }
}
