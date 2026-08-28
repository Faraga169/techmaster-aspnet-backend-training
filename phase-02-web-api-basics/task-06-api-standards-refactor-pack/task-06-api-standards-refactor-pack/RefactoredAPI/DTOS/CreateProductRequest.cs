using System.ComponentModel.DataAnnotations;

namespace task_06_api_standards_refactor_pack.RefactoredAPI.DTOS
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(17, ErrorMessage = "Name must be less than 17 characters")]
        public string Name { get; set; } = null!;

        [DataType(DataType.Currency)]
        [Range(100, 1000000, ErrorMessage = "Price must be in range between 100 and 1000000")]
        public decimal Price { get; set; }

        [Range(1, 1000000, ErrorMessage = "Stock must be in range between 1 and 1000000")]
        public int Stock { get; set; }
    }
}
