using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class CreateEnrollDTO
    {
        public DateTime EnrollmentDate { get; set; }

        public decimal ProgressPercentage { get; set; }

        public EnrollmentStatus Status { get; set; }

        public string? FinalResult { get; set; }

        public int StudentId { get; set; }

        public int TrainingTrackId { get; set; }

    }
}
