using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class TopTrack
    {
        public string TrackName { get; set; } = null!;
        public int EnrollmentCount { get; set; }
    }
}
