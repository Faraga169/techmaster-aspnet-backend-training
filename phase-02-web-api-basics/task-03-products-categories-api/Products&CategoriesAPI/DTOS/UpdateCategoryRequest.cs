using System.ComponentModel.DataAnnotations;
using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.DTOS
{
    public class UpdateCategoryRequest
    {

        [Required(ErrorMessage = "CategoryName is Required")]
        public string Name { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Description characters must be less than 100")]
        public string? Description { get; set; }

        public bool IsActive { get; set; }

      
    }
}
