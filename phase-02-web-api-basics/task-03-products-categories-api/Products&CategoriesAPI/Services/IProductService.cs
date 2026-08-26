using Products_CategoriesAPI.DTOS;

namespace Products_CategoriesAPI.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductResponse> GetAll();

        public ProductResponse GetById(Guid Id);

        public ProductResponse Add(CreateProductRequest createProductRequest);

        public ProductResponse Update(Guid Id, UpdateProductRequest updateProductRequest);

        public void Delete(Guid Id);
    }
}
