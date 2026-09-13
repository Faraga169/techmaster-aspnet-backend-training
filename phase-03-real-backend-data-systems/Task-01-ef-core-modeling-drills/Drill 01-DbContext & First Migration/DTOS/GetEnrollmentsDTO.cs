using Drill_01_DbContext___First_Migration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Drill_01_DbContext___First_Migration.DTOS
{
    public class GetEnrollmentsDTO
    {


        public string StudentName { get; set; } = null!;


        public string TrackName { get; set; } = null!;

        public decimal TotalRequired { get; set; }

        public decimal TotalPaid { get; set; }

        public decimal RemainingAmount { get; set; }

        public string PaymentStatus { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        public decimal FinalGrade { get; set; }
    }
}
