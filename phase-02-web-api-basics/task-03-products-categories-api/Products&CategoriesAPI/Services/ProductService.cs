using Products_CategoriesAPI.DTOS;
using Products_CategoriesAPI.Models;
using Products_CategoriesAPI.Seeding;
using StudentManagementAPI.Exceptions;

namespace Products_CategoriesAPI.Services
{
    public class ProductService:IProductService
    {
        public IEnumerable<ProductResponse> GetAll()
        {
            var Products = ProductsSeeding.Products.ToList();
            var Categories = ProductsSeeding.Categories.ToList();

            var ProductResponseDTO = Products.Select(p => new ProductResponse()
            {
                Name = p.Name,
                Price = p.Price,
                IsAvailable = p.IsAvailable,
                StockQuantity = p.StockQuantity,
                SupplierName = p.SupplierName,
                CategoryName = Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name??"Unknown",

            }).ToList();
                
                

            return ProductResponseDTO;
        }

        public ProductResponse GetById(Guid Id)
        {
            var Product = ProductsSeeding.Products.Find(p => p.Id == Id);
            var Categories = ProductsSeeding.Categories.ToList();
            if (Product is null)
                throw new BusinessException("Product is not found", 404);

            var ProductResponseDTO = new ProductResponse()
            {
                Id = Product.Id,
                Name = Product.Name,
                IsAvailable= Product.IsAvailable,
                Price= Product.Price,
                StockQuantity= Product.StockQuantity,
                SupplierName= Product.SupplierName,
                CategoryName =  Categories.FirstOrDefault(c => c.Id ==Product.CategoryId)?.Name ?? "Unknown",

            };

            return ProductResponseDTO;
        }

        public ProductResponse Add(CreateProductRequest createProductRequest)
        {
          
            if (string.IsNullOrWhiteSpace(createProductRequest.Name))
            {

                throw new BusinessException("Product Name is Required", 400);

            }

            if (string.IsNullOrWhiteSpace(createProductRequest.SupplierName))
            {

                throw new BusinessException("Supplier Name is Required", 400);

            }
            if (createProductRequest.Price<0)
                throw new BusinessException("Product Price must be positive", 400);

            if (createProductRequest.StockQuantity < 0)
                throw new BusinessException("stockQuantity must be positive", 400);

            var existproductname = ProductsSeeding.Products.Any(c => c.Name.Equals(createProductRequest.Name, StringComparison.OrdinalIgnoreCase));

            if (existproductname)
                throw new BusinessException("Product Name must be unique", 400);

           
           
            var category= ProductsSeeding.Categories.FirstOrDefault(c => c.Id==createProductRequest.CategoryId);
            
            if(category is  null)
                throw new BusinessException("Category not found", 404);

            var Product = new Product()
            {

                Id = Guid.NewGuid(),
                Name = createProductRequest.Name,
                Price = createProductRequest.Price,
                IsAvailable = createProductRequest.IsAvailable,
                StockQuantity = createProductRequest.StockQuantity,
                SupplierName = createProductRequest.SupplierName,
                CategoryId = createProductRequest.CategoryId
            };

            ProductsSeeding.Products.Add(Product);
            category.Products.Add(Product);

            var ProductResponseDTO = new ProductResponse()
            {
                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                IsAvailable = Product.IsAvailable,
                StockQuantity = Product.StockQuantity,
                SupplierName = Product.SupplierName,
                CategoryName = category.Name
            };

            return ProductResponseDTO;
        }


        public ProductResponse Update(Guid Id, UpdateProductRequest updateProductRequest)
        {
            if (string.IsNullOrWhiteSpace(updateProductRequest.Name))
            {

                throw new BusinessException("Product Name is Required", 400);

            }

            if (string.IsNullOrWhiteSpace(updateProductRequest.SupplierName))
            {

                throw new BusinessException("Supplier Name is Required", 400);

            }
            if (updateProductRequest.Price < 0)
                throw new BusinessException("Product Price must be positive", 400);

            if (updateProductRequest.StockQuantity < 0)
                throw new BusinessException("stockQuantity must be positive", 400);

            var existproductname = ProductsSeeding.Products.Any(c => c.Name.Equals(updateProductRequest.Name, StringComparison.OrdinalIgnoreCase)&&c.Id!=Id);

            if (existproductname)
                throw new BusinessException("Product Name must be unique", 400);



            var product = ProductsSeeding.Products.FirstOrDefault(p => p.Id == Id);

            if (product is null)
                throw new BusinessException("product not found", 404);
            
            var oldcategory = ProductsSeeding.Categories.FirstOrDefault(c => c.Id == product.CategoryId);
            var newcategory = ProductsSeeding.Categories.FirstOrDefault(c => c.Id == updateProductRequest.CategoryId);
            if (oldcategory is null)
                throw new BusinessException("Category not found", 404);

            if (oldcategory != newcategory) {

                oldcategory?.Products.Remove(product);
                newcategory?.Products.Add(product);
            }

            product.Name = updateProductRequest.Name;
            product.Price = updateProductRequest.Price;
            product.IsAvailable = updateProductRequest.IsAvailable;
            product.StockQuantity = updateProductRequest.StockQuantity;
            product.SupplierName = updateProductRequest.SupplierName;
            product.CategoryId = updateProductRequest.CategoryId;
            

            

            var ProductResponseDTO = new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                StockQuantity = product.StockQuantity,
                SupplierName = product.SupplierName,
                CategoryName = ProductsSeeding.Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Unknown",
            };

            return ProductResponseDTO;
        }


        public void Delete(Guid Id)
        {
            var Product = ProductsSeeding.Products.Find(c => c.Id == Id);
            if (Product is null)
                throw new BusinessException("Product is not found", 404);

            var productexistcategory = ProductsSeeding.Categories.FirstOrDefault(c => c.Id == Product.CategoryId);

            if (productexistcategory is not null)
                throw new BusinessException("Cannot delete product related to category", 400);

            productexistcategory?.Products.Remove(Product);
            ProductsSeeding.Products.Remove(Product);
        }


    }
}
