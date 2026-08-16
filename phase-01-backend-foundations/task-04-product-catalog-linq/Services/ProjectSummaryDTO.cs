using System;
using System.Collections.Generic;
using System.Text;

namespace task_04_product_catalog_linq.Services
{
    public class ProjectSummaryDTO
    {

        public string Name { get; set; } = null!;

        public decimal Price { get;  set; }

        public int StockQuantity { get;  set; }

        public string Status { get;  set; } = null!;

    }
}
