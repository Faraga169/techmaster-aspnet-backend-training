using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class TrackStudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public string EnrollmentStatus { get; set; } = null!;
        public DateOnly EnrollmentDate { get; set; }
    }
}
