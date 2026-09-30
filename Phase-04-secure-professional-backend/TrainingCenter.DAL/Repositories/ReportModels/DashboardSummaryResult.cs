using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class DashboardSummaryResult
    {
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int TotalInstructors { get; set; }
        public int TotalTracks { get; set; }
        public int ActiveTracks { get; set; }
        public int TotalEnrollments { get; set; }
        public int ActiveEnrollments { get; set; }
        public int TotalPayments { get; set; }
    }
}
