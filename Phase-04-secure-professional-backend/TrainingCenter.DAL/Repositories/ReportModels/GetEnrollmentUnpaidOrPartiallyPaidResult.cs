using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class GetEnrollmentUnpaidOrPartiallyPaidResult
    {
        public int EnrollId { get; set; }

        public string TrackName { get; set; } = null!;

        public string StudentName { get; set; } = null!;

        public decimal RemainingAmount { get; set; }

    }
}
