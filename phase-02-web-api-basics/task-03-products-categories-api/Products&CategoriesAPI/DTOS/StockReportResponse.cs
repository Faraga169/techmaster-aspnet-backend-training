namespace Products_CategoriesAPI.DTOS
{
    public class StockReportResponse
    {
        public int TotalStock { get; set; }

        public List<stockperCategoryResponse> TotalStockPerCategory { get; set; }=new List<stockperCategoryResponse>();

        public List<ProductResponse> LowStockProducts { get; set; }=new List<ProductResponse>();

        public List<ProductResponse> OutStockProducts { get; set; } = new List<ProductResponse>();

        public List<ProductsperCategoryResponse> NumberofproductsperCategory { get; set; }= new List<ProductsperCategoryResponse>();

    }
}
