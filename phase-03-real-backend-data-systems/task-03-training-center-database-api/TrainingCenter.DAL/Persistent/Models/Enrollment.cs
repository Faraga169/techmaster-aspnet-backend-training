using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class Enrollment:BaseEntity<int>
    {
        //        EnrollmentId PK
        //StudentId FK
        //TrainingTrackId FK
        //EnrollmentDate
        //Status
        //ProgressPercentage
        //FinalResult optional
        //CreatedAt UTC
        //UpdatedAt nullable


        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        [Range(0,100,ErrorMessage ="Progress Percentage must between 0 and 100")]
        public decimal ProgressPercentage { get; set; }

        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;


        public string? FinalResult { get; set; }

        public Student? Student { get; set; }

        public TrainingTrack? TrainingTrack { get; set; }

        public int StudentId { get; set; }

        public int TrainingTrackId { get; set; }

        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();

    }
}
