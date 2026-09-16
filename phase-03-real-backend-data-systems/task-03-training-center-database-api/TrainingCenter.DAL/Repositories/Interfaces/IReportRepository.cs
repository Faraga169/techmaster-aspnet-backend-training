using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<DashboardSummaryResult> GetDashboardSummary(); 
        Task<IEnumerable<Enrollment>> GetUnpaidOrPartiallyPaid(); 
        Task<IEnumerable<TrackCapacityResult>> GetCapacityByTrack(); 
        Task<RevenueSummaryResult> GetRevenueSummary(); 
        Task<IEnumerable<RevenueByTrackResult>> GetRevenueByTrack();

        public Task<IEnumerable<TopTrack>> TopTracks();

        public Task<IEnumerable<Student>> studentswithoutpayments();

        public Task<IEnumerable<InstructorWorkload>> GetInstructorWorkload();
    }
}
