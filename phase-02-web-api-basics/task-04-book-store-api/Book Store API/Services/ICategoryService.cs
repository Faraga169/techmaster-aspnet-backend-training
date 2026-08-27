using Book_Store_API.DTOS;

namespace Book_Store_API.Services
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryResponse> GetAll();

        public CategoryResponse Create(CreateCategoryRequest createCategory);

        public void Delete(int id);
    }
}
