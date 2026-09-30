using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class InstructorWorkload
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = null!;
        public int TrackCount { get; set; }
        public int ActiveStudentCount { get; set; }
    }
}
