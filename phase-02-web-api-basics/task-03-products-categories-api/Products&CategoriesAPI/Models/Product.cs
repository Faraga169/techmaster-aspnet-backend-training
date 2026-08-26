using System.ComponentModel.DataAnnotations;

namespace Products_CategoriesAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

       
        public decimal Price { get; set; }

        
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }


        public string SupplierName { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Category Category { get; set; } = null!;

        public Guid? CategoryId { get; set; }
    }
}
