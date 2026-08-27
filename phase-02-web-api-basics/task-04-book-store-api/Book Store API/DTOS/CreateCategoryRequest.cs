using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.DTOS
{
    public class CreateCategoryRequest
    {

        [Required(ErrorMessage = "Category Name is Required")]
        public string Name { get; set; } = null!;

        [StringLength(200, ErrorMessage = "Description must not exceed 200 characters")]
        public string? Description { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
