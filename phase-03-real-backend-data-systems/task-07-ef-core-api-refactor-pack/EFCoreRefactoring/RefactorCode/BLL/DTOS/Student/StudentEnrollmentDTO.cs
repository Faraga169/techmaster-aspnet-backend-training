using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Student
{
    public class StudentEnrollmentDTO
    {
        public string FullName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public List<EnrollmentDTO> Enrollments { get; set; } = new List<EnrollmentDTO>();


    }
}
