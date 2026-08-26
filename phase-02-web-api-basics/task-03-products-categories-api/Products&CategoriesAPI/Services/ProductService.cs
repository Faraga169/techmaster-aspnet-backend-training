using System.Xml.Linq;
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
                Id=p.Id,
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

                throw new BusinessException("Product Name is Required", 400);


            if (string.IsNullOrWhiteSpace(createProductRequest.SupplierName))

                throw new BusinessException("Supplier Name is Required", 400);


            if (createProductRequest.Price<0)
                throw new BusinessException("Product Price must be positive", 400);

            if (createProductRequest.StockQuantity < 0)
                throw new BusinessException("stockQuantity must be positive", 400);

            var existproductname = ProductsSeeding.Products.Any(c => c.Name.Equals(createProductRequest.Name, StringComparison.OrdinalIgnoreCase));

            if (existproductname)
                throw new BusinessException("Product Name must be unique", 400);

           
           
            var category= ProductsSeeding.Categories.Find(c => c.Id==createProductRequest.CategoryId);
            
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

            productexistcategory?.Products.Remove(Product);
            ProductsSeeding.Products.Remove(Product);
        }


        public IEnumerable<ProductResponse> Search(string name) {

            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException("Product name is required", 400);

            var searchName = ProductsSeeding.Products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if(searchName.Count==0)
                throw new BusinessException("No Product name match ", 404);
            var ProductResponseDTO = searchName.Select(s => new ProductResponse() {
              Id=  s.Id,
              Name=  s.Name,
              Price=  s.Price,
             IsAvailable= s.IsAvailable,
             StockQuantity= s.StockQuantity,
             SupplierName= s.SupplierName,
             CategoryName=ProductsSeeding.Categories.FirstOrDefault(c => c.Id == s.CategoryId)?.Name ?? "Unknown"

            }

            ).ToList();

            return ProductResponseDTO;
        }


        public IEnumerable<ProductResponse> Filter(string? CategoryName, bool? availability, decimal? maxprice, decimal? minprice, int? lowstock) {

            var Filterproducts=ProductsSeeding.Products.ToList();
            if (!string.IsNullOrWhiteSpace(CategoryName)) {

                var category = ProductsSeeding.Categories.FirstOrDefault(c =>c.Name.Equals(CategoryName, StringComparison.OrdinalIgnoreCase));

                if (category is null)
                    throw new BusinessException("Category not found", 404);

                Filterproducts = Filterproducts.Where(p => p.CategoryId == category.Id).ToList();

            }

            if (minprice.HasValue&&minprice < 0)
                throw new BusinessException("Min price cannot be negative", 400);

            if (minprice.HasValue && maxprice.HasValue &&maxprice < minprice)
                throw new BusinessException("Max price must be greater than or equal to min price", 400);

            if (minprice.HasValue)
                Filterproducts = Filterproducts.Where(p => p.Price >= minprice.Value).ToList();

            if (maxprice.HasValue&&maxprice.HasValue)
                Filterproducts = Filterproducts.Where(p => p.Price <= maxprice.Value).ToList();


            if (lowstock.HasValue && lowstock <= 0)
                throw new BusinessException("low stock must be greater than 0", 400);

            if (lowstock.HasValue) {
                Filterproducts = Filterproducts.Where(f => f.StockQuantity<=lowstock).ToList();
            }

            if (availability is not null) {

                Filterproducts = Filterproducts.Where(f => f.IsAvailable == availability).ToList();
            }

            if (Filterproducts.Count == 0)
                throw new BusinessException("No Products Found", 404);

            var ProductResponseDTO = Filterproducts.Select(s => new ProductResponse()
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                IsAvailable = s.IsAvailable,
                StockQuantity = s.StockQuantity,
                SupplierName = s.SupplierName,
                CategoryName = ProductsSeeding.Categories.FirstOrDefault(c => c.Id == s.CategoryId)?.Name ?? "Unknown"

            }

           ).ToList();

            return ProductResponseDTO;



        }



        public StockReportResponse StockReport() {

            var stockReport = ProductsSeeding.Products.ToList();

            var totalstock = stockReport.Sum(s=>s.StockQuantity);

            var stockpercategory = stockReport.GroupBy(s => s.Category).Select(s => new stockperCategoryResponse { CategoryName = s.Key.Name, Count =s.Sum(s=>s.StockQuantity) }).ToList();

            var lowstockproducts = stockReport.Where(s => s.StockQuantity <= 5).Select(s=>new ProductResponse() { 
            
                Id=s.Id,
                Name=s.Name,
                IsAvailable=s.IsAvailable,
                Price=s.Price,
                StockQuantity=s.StockQuantity,
                SupplierName=s.SupplierName,
                CategoryName=ProductsSeeding.Categories.FirstOrDefault(c=>c.Id==s.CategoryId)?.Name??"Unknown"
            
            }).ToList();

            var outstockproducts= stockReport.Where(s => s.StockQuantity ==0).Select(s => new ProductResponse()
            {

                Id = s.Id,
                Name = s.Name,
                IsAvailable = s.IsAvailable,
                Price = s.Price,
                StockQuantity = s.StockQuantity,
                SupplierName = s.SupplierName,
                CategoryName = ProductsSeeding.Categories.FirstOrDefault(c => c.Id == s.CategoryId)?.Name ?? "Unknown"

            }).ToList();

            var countproductspercategory = stockReport.GroupBy(s => s.Category).Select(s => new ProductsperCategoryResponse { CategoryName = s.Key.Name, Count = s.Count() }).ToList();


            var stockreportResponse = new StockReportResponse()
            {

                TotalStock = totalstock,
                LowStockProducts = lowstockproducts,
                OutStockProducts = outstockproducts,
                TotalStockPerCategory = stockpercategory,
                NumberofproductsperCategory=countproductspercategory
            };

            return stockreportResponse;
        }


    }
}
