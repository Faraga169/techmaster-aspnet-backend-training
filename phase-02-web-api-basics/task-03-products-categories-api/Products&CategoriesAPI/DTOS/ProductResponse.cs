using System.ComponentModel.DataAnnotations;
using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.DTOS
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

      
        public decimal Price { get; set; }

       
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }


        public string SupplierName { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

    }
}
