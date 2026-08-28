using task_06_api_standards_refactor_pack.OriginalBadCode;
using task_06_api_standards_refactor_pack.RefactoredAPI.DTOS;

namespace task_06_api_standards_refactor_pack.RefactoredAPI.Services
{
    public interface IProductService
    {
        ProductResponse Create(CreateProductRequest createProduct);

        ProductResponse GetById(int id);

        IEnumerable<ProductResponse> GetAll();

       
    }
}
