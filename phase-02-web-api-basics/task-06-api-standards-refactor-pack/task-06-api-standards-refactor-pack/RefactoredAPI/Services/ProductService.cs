using task_06_api_standards_refactor_pack.Exceptions;
using task_06_api_standards_refactor_pack.OriginalBadCode;
using task_06_api_standards_refactor_pack.RefactoredAPI.DTOS;
using task_06_api_standards_refactor_pack.RefactoredAPI.Seeding;

namespace task_06_api_standards_refactor_pack.RefactoredAPI.Services
{
    public class ProductService:IProductService
    {
        public ProductResponse Create(CreateProductRequest createProduct)
        {
            var result = ProductsSeeding.Products.Any(s => s.Name.Equals(createProduct.Name));

            if (result)
                throw new BusinessException("Email must be unique", 400);

            var Product = new Product()
            {
                Id = ProductsSeeding.Products.Any()? ProductsSeeding.Products.Max(s=>s.Id)+1:1,
                Name= createProduct.Name,
                Price= createProduct.Price,
                Stock=createProduct.Stock
            };

            ProductsSeeding.Products.Add(Product);

            var productResponseDTo = new ProductResponse()
            {

                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                Stock = Product.Stock

            };


            return productResponseDTo;



        }


        public ProductResponse GetById(int id)
        {

            var product = ProductsSeeding.Products.Find(s => s.Id == id);
            if (product is null)
            {

                throw new BusinessException("product not found", 404);
            }

            var productResponseDto = new ProductResponse()
            {

                Id = id,
                Name= product.Name,
                Price=product.Price,
                Stock=product.Stock
            };

            return productResponseDto;

        }

        public IEnumerable<ProductResponse> GetAll()
        {


            var productsResponseDto =ProductsSeeding.Products.Select(s=>new ProductResponse() { 
            
                Id= s.Id,
                Name=s.Name,
                Price=s.Price,
                Stock = s.Stock
            
            }).ToList() ;
           
            return productsResponseDto;

        }
       
    }
}
