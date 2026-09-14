using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class TrackCapacityResult
    {
        public int TrackId { get; set; }
        public string TrackTitle { get; set; } = null!; public int Capacity { get; set; }
        public int EnrolledStudents { get; set; }
        public int AvailableSeats { get; set; }
    }
}
