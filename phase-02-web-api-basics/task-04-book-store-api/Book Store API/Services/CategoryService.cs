using Book_Store_API.DTOS;
using Book_Store_API.Exceptions;
using Book_Store_API.Models;
using Book_Store_API.Seeding;

namespace Book_Store_API.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<CategoryResponse> GetAll()
        {
            var Categories = BookSeeding.Categories.ToList();
            var CategoryResponseDTO = Categories.Select(s => new CategoryResponse()
            {
                Id = s.Id,
               Description= s.Description,
               IsActive=s.IsActive,
               Name = s.Name

            }).ToList();

            return CategoryResponseDTO;
        }

        public CategoryResponse Create(CreateCategoryRequest createCategory)
        {
            if (string.IsNullOrWhiteSpace(createCategory.Name))
                throw new BusinessException("Category Name is Required", 400);
            

            var Category = BookSeeding.Categories.Find(b => b.Name.Equals(createCategory.Name, StringComparison.OrdinalIgnoreCase));

            if (Category is not null)
                throw new BusinessException("Category Name must be unique", 400);

            var CreateCategory = new Category()
            {

                Id = BookSeeding.Categories.Any() ? BookSeeding.Categories.Max(s => s.Id) + 1 : 1,
                Description = createCategory.Description,
                IsActive = createCategory.IsActive,
                Name = createCategory.Name

            };

            BookSeeding.Categories.Add(CreateCategory);

            var CreateCategoryRequestDTO = new CategoryResponse()
            {

                Id = CreateCategory.Id,
                Name = CreateCategory.Name,
                Description = CreateCategory.Description,
                IsActive = CreateCategory.IsActive
            };

            return CreateCategoryRequestDTO;
        }

        public void Delete(int id)
        {
            var Category = BookSeeding.Categories.Find(s => s.Id == id);
            if (Category is null)
                throw new BusinessException("Category Not Found", 404);

            var CategoryexistBooks = BookSeeding.Books.FirstOrDefault(s => s.CategoryId == id);

            if (CategoryexistBooks is not null)
                throw new BusinessException("Category cannot delete because related to books", 404);

            BookSeeding.Categories.Remove(Category);
        }

      
    }
}
