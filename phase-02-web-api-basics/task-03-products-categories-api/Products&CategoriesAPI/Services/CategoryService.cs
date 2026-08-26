using Products_CategoriesAPI.DTOS;
using Products_CategoriesAPI.Models;
using Products_CategoriesAPI.Seeding;
using StudentManagementAPI.Exceptions;

namespace Products_CategoriesAPI.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<CategoryResponse> GetAll()
        {
            var Categories = ProductsSeeding.Categories.Where(c=>c.IsActive).ToList();

            var CategoryResponseDTO = Categories.Select(
                c => new CategoryResponse()
                {
                    Id=c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    Products = c.Products.Where(p => p.CategoryId == c.Id).Select(
                 p => new ProductResponse()
                 {
                     Id=p.Id,
                     Name = p.Name,
                     Price = p.Price,
                     IsAvailable = p.IsAvailable,
                     StockQuantity = p.StockQuantity,
                     SupplierName = p.SupplierName
                 }).ToList()
                }
                );
           
            return CategoryResponseDTO;
        }

        public CategoryResponse GetById(Guid Id)
        {
            var Category = ProductsSeeding.Categories.Find(c => c.Id == Id);
            if (Category is null)
                throw new BusinessException("Category is not found", 404);

            var CategoryResponseDTO = new CategoryResponse()
            {
                Id=Category.Id,
                Name = Category.Name,
                Description = Category.Description,
                IsActive = Category.IsActive,
                Products = Category.Products.Select(p => new ProductResponse()
                {
                    Id=p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    IsAvailable = p.IsAvailable,
                    StockQuantity = p.StockQuantity,
                    SupplierName = p.SupplierName

                }).ToList()
            };

            return CategoryResponseDTO;
        }

        public CategoryResponse Add(CreateCategoryRequest createCategoryRequest)
        {
            if (string.IsNullOrWhiteSpace(createCategoryRequest.Name)) {

                throw new BusinessException("Category Name is Required", 400);

            }

            var existcategoryname = ProductsSeeding.Categories.Any(c => c.Name.Equals(createCategoryRequest.Name, StringComparison.OrdinalIgnoreCase));

            if(existcategoryname)
                throw new BusinessException("Category Name must be unique", 400);

            var Category = new Category()
            {

                Id = Guid.NewGuid(),
                Name = createCategoryRequest.Name,
                Description = createCategoryRequest.Description,
                IsActive = createCategoryRequest.IsActive
            };

            ProductsSeeding.Categories.Add(Category);

            var CategoryResponseDTO = new CategoryResponse()
            {
                Id=Category.Id,
                Name = Category.Name,
                Description = Category.Description,
                IsActive = Category.IsActive
            };

            return CategoryResponseDTO;
        }


        public CategoryResponse Update(Guid Id, UpdateCategoryRequest updateCategoryRequest)
        {
            var Category = ProductsSeeding.Categories.Find(c => c.Id == Id);
            if (Category is null)
                throw new BusinessException("Category is not found", 404);

            var existcategoryname = ProductsSeeding.Categories.Any(c => c.Name.Equals(updateCategoryRequest.Name, StringComparison.OrdinalIgnoreCase)&&c.Id!=Id);

            if (existcategoryname)
                throw new BusinessException("Category Name must be unique", 400);

            if (string.IsNullOrWhiteSpace(updateCategoryRequest.Name))
            {

                throw new BusinessException("Category Name is Required", 400);

            }


            Category.Name = updateCategoryRequest.Name;
            Category.Description = updateCategoryRequest.Description;
            Category.IsActive = updateCategoryRequest.IsActive;
            

            var CategoryResponseDTO = new CategoryResponse()
            {

                Name = Category.Name,
                Description = Category.Description,
                IsActive = Category.IsActive
            };

            return CategoryResponseDTO;
        }


        public void Delete(Guid Id)
        {
            var Category = ProductsSeeding.Categories.Find(c => c.Id == Id);
            if (Category is null)
                throw new BusinessException("Category is not found", 404);

            var categoryexistproducts = ProductsSeeding.Products.Where(p => p.CategoryId == Id);

            if(categoryexistproducts.Count()>0)
                throw new BusinessException("Cannot delete category because it contains products",400);

            ProductsSeeding.Categories.Remove(Category);
        }

       

      
    }
}
