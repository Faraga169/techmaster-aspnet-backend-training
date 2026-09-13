using Drill_01_DbContext___First_Migration.Models;

namespace Drill_01_DbContext___First_Migration.DTOS
{
    public class StudentwithEnrollmentDTO
    {
        public string StudentName { get; set; } = null!;

        public string Status { get; set; } 

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        public decimal FinalGrade { get; set; }

    }
}
