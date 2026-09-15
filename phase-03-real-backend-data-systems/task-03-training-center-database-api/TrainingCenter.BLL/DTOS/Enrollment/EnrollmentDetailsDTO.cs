using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class EnrollmentDetailsDTO
    {
        public DateTime EnrollmentDate { get; set; }

        public decimal ProgressPercentage { get; set; }

        public EnrollmentStatus Status { get; set; }


        public string? FinalResult { get; set; }
        public StudentDTO Student { get; set; } = null!;

        public TrackDTO TrainingTrack { get; set; } = null!;

        public List<PaymentDTO> Payments { get; set; } = new List<PaymentDTO>();
    }
}
