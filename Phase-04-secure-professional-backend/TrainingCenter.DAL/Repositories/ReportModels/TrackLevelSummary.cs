using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class TrackLevelSummary
    {


        //"trackId": 2,
        //"trackName": ".NET Backend",
        //"totalEnrollments": 20,
        //"pendingCount": 2,
        //"activeCount": 12,
        //"completedCount": 5,
        //"cancelledCount": 1,
        //"completionPercentage": 25

        public string TrackName { get; set; } = null!;

        public int TotalEnrollments { get; set; }

        public int PendingCount { get; set; }

        public int ActiveCount { get; set; }

        public int CompleteCount { get; set; }

        public int CancelledCount { get; set; }

        public double CompletionPercentage { get; set; }

    }
}
