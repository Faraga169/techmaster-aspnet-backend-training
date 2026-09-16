using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class ReportRepository(AppDbContext dbContext) : IReportRepository
    {

        public async Task<DashboardSummaryResult> GetDashboardSummary() 
        { 
            var result = new DashboardSummaryResult 
            { 
                TotalStudents = await dbContext.Students.CountAsync(), 
                ActiveStudents = await dbContext.Students.CountAsync(s => s.IsActive && !s.IsDeleted), 
                TotalInstructors = await dbContext.Instructors.CountAsync(), 
                TotalTracks = await dbContext.TrainingTracks.CountAsync(), 
                ActiveTracks = await dbContext.TrainingTracks.CountAsync(t => t.Status == TrainingStatus.Active && !t.IsDeleted), 
                TotalEnrollments = await dbContext.Enrollmets.CountAsync(), 
                ActiveEnrollments = await dbContext.Enrollmets.CountAsync(e => e.Status == EnrollmentStatus.Active), 
                TotalPayments = await dbContext.Payments.CountAsync() }; 
            return result; 
        
        }
        public async Task<IEnumerable<TrackCapacityResult>> GetCapacityByTrack()
        {
            return await dbContext.TrainingTracks.AsNoTracking()
                .Select(t =>
                new TrackCapacityResult
                {
                    TrackId = t.Id,
                    TrackTitle = t.Title,
                    Capacity = t.Capacity,
                    EnrolledStudents = t.Enrollments.Count(),
                    AvailableSeats = t.Capacity - t.Enrollments.Count()
                }).ToListAsync();
        }

       

        public async Task<IEnumerable<RevenueByTrackResult>> GetRevenueByTrack()
        {
            return await dbContext.Payments.Where(p => p.Status == PaymentStatus.Paid)
                                      .GroupBy(p => p.Enrollment!.TrainingTrack!.Title)
                                      .Select(g => 
                                      new RevenueByTrackResult 
                                      { 
                                          TrackName = g.Key,
                                          TotalRevenue = g.Sum(p => p.Amount), 
                                          PaymentCount = g.Count() })
                                      .AsNoTracking()
                                      .ToListAsync();
        }


        public async Task<IEnumerable<TopTrack>> TopTracks()
        {
            return await dbContext.Enrollmets
      .Where(e => e.Status == EnrollmentStatus.Active)
      .GroupBy(e => e.TrainingTrack!.Title)
      .Select(g => new TopTrack
      {
          TrackName = g.Key,
          EnrollmentCount = g.Count()
      })
      .OrderByDescending(x => x.EnrollmentCount)
      .Take(5)
      .AsNoTracking()
      .ToListAsync();
        }



        public async Task<IEnumerable<InstructorWorkload>> GetInstructorWorkload()
        {
            return await dbContext.TrainingTracks
                .GroupBy(t => new
                {
                    t.InstructorId,
                    InstructorName = t.Instructor!.FullName
                })
                .Select(g => new InstructorWorkload
                {
                    InstructorId = g.Key.InstructorId,
                    InstructorName = g.Key.InstructorName,

                    TrackCount = g.Count(),

                    ActiveStudentCount = g
                        .SelectMany(t => t.Enrollments)
                        .Count(e => e.Status == EnrollmentStatus.Active)
                })
                .AsNoTracking()
                .ToListAsync();
        }



        public async Task<IEnumerable<Student>> studentswithoutpayments()
        {
           return await dbContext.Students
                .Where(s => s.Enrollments.Any(e => (e.Status == EnrollmentStatus.Active || e.Status == EnrollmentStatus.Pending) && s.Enrollments.Any(e => !e.Payments.Any() || e.Payments.Any(p => p.Status != PaymentStatus.Paid)))).AsNoTracking().ToListAsync();

          
        }



        public async Task<RevenueSummaryResult> GetRevenueSummary()
        {
            return new RevenueSummaryResult 
            { 
                TotalRevenue = await dbContext.Payments.Where(p => p.Status == PaymentStatus.Paid).SumAsync(p => p.Amount),
                TotalPayments = await dbContext.Payments.CountAsync(), 
                PaidPayments = await dbContext.Payments.CountAsync(p => p.Status == PaymentStatus.Paid), 
                PendingPayments = await dbContext.Payments.CountAsync(p => p.Status == PaymentStatus.Pending), 
                FailedPayments = await dbContext.Payments.CountAsync(p => p.Status == PaymentStatus.Failed), 
                RefundedPayments = await dbContext.Payments.CountAsync(p => p.Status == PaymentStatus.Refunded) 
            };
        }

        public async Task<IEnumerable<GetEnrollmentUnpaidOrPartiallyPaidResult>>
     GetUnpaidOrPartiallyPaid()
        {
            return await dbContext.Enrollmets.Where(e =>!e.Payments.Any() ||e.Payments
                        .Where(p => p.Status == PaymentStatus.Paid)
                        .Sum(p => p.Amount) < e.TrainingTrack!.Price
                )
                .Select(e => new GetEnrollmentUnpaidOrPartiallyPaidResult
                {
                    EnrollId = e.Id,
                    StudentName = e.Student!.FullName,
                    TrackName = e.TrainingTrack!.Title,

                    RemainingAmount =
                        e.TrainingTrack.Price -
                        e.Payments
                            .Where(p => p.Status == PaymentStatus.Paid)
                            .Sum(p => p.Amount)
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
