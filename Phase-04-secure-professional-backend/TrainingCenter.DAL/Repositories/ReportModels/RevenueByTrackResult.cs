using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Repositories.ReportModels
{
    public class RevenueByTrackResult
    {
        public string TrackName { get; set; } = null!;
        public decimal TotalRevenue { get; set; }
        public int PaymentCount { get; set; }
    }
}
