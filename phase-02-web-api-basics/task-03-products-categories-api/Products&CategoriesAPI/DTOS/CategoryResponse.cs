using System.ComponentModel.DataAnnotations;
using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.DTOS
{
    public class CategoryResponse
    {

        public string Name { get; set; } = null!;

    
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }
}
