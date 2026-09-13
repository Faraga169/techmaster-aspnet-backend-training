using Drill_01_DbContext___First_Migration.Models;

namespace Drill_01_DbContext___First_Migration.DTOS
{
    public class CreateStudentDTO
    {
      

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;


    }
}
