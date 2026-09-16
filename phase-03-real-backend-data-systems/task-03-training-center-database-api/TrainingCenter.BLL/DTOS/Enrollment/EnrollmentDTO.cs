using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }


        [Range(0, 100, ErrorMessage = "Progress Percentage must between 0 and 100")]
        public decimal ProgressPercentage { get; set; }

        public EnrollmentStatus Status { get; set; }


        public string? FinalResult { get; set; }

        public string StudentName { get; set; } = null!;
        public string TrainingTrackName { get; set; } = null!;
    }
}
