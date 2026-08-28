using System.ComponentModel.DataAnnotations;

namespace task_06_api_standards_refactor_pack.RefactoredAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
