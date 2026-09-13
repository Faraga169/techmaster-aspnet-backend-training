using Drill_01_DbContext___First_Migration.Models;

namespace Drill_01_DbContext___First_Migration.DTOS
{
    public class StudentProfileDTO
    {

        public string FullName { get; set; } = null!;
        public long NationalId { get; set; }

        public string EmergencyPhone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

    }
}
