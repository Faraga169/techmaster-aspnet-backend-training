using Products_CategoriesAPI.DTOS;
using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.Services
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryResponse> GetAll();

        public CategoryResponse GetById(Guid Id);

        public CategoryResponse Add(CreateCategoryRequest createCategoryRequest);

        public CategoryResponse Update(Guid Id,UpdateCategoryRequest updateCategoryRequest);

        public void Delete(Guid Id);

    }
}
