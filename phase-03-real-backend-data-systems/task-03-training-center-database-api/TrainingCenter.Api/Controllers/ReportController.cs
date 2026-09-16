using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportRepository reportsRepository) : ControllerBase
    {
        [HttpGet("dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            var result = await reportsRepository.GetDashboardSummary();

            return Ok(new ApiResponse<DashboardSummaryResult>
            {
                Success = true,
                Message = "Dashboard summary retrieved successfully.",
                Data = result
            });
        }

        [HttpGet("unpaid-enrollments")]
        public async Task<IActionResult> GetUnpaidEnrollments()
        {
            var result = await reportsRepository.GetUnpaidOrPartiallyPaid();



            var UnpaidOrPartiallyPaidEnrollmentDTO = result.Select(e => new UnpaidOrPartiallyPaidEnrollmentDTO() {

                EnrollmentId = e.Id,
                Payments = e.Payments.Select(p=>new PaymentDTO() { 
                Amount = p.Amount,
                Status= p.Status,
                PaymentDate=p.PaymentDate,
                PaymentMethod=p.PaymentMethod,
                ReferenceNumber=p.ReferenceNumber,
                Id=p.Id,
                Notes=p.Notes
                }).ToList(),
                StudentName = e.Student!.FullName,
                TrackName = e.TrainingTrack!.Title

            });

            return Ok(new ApiResponse<IEnumerable<UnpaidOrPartiallyPaidEnrollmentDTO>>
            {
                Success = true,
                Message = "Unpaid enrollments retrieved successfully.",
                Data = UnpaidOrPartiallyPaidEnrollmentDTO
            });
        }

        [HttpGet("track-capacity")]
        public async Task<IActionResult> GetTrackCapacity()
        {
            var result = await reportsRepository.GetCapacityByTrack();

            return Ok(new ApiResponse<IEnumerable<TrackCapacityResult>>
            {
                Success = true,
                Message = "Track capacity retrieved successfully.",
                Data = result
            });
        }

        [HttpGet("revenue-summary")]
        public async Task<IActionResult> GetRevenueSummary()
        {
            var result = await reportsRepository.GetRevenueSummary();

            return Ok(new ApiResponse<RevenueSummaryResult>
            {
                Success = true,
                Message = "Revenue summary retrieved successfully.",
                Data = result
            });
        }

        [HttpGet("revenue-by-track")]
        public async Task<IActionResult> GetRevenueByTrack()
        {
            var result = await reportsRepository.GetRevenueByTrack();

            return Ok(new ApiResponse<IEnumerable<RevenueByTrackResult>>
            {
                Success = true,
                Message = "Revenue by track retrieved successfully.",
                Data = result
            });
        }



        [HttpGet("top-tracks")]
        public async Task<IActionResult> GetTopTracks()
        {
            var result = await reportsRepository.TopTracks();

            return Ok(new ApiResponse<IEnumerable<TopTrack>>
            {
                Success = true,
                Message = "Top 5 Tracks retrieved successfully.",
                Data = result
            });

        }

        [HttpGet("instructor-workload")]
        public async Task<IActionResult> GetInstrucorWorkload()
        {
            var result = await reportsRepository.GetInstructorWorkload();

            return Ok(new ApiResponse<IEnumerable<InstructorWorkload>>
            {
                Success = true,
                Message = "Number of tracks and number of active students retrieved successfully.",
                Data = result
            });

        }


        [HttpGet("students-without-payments")]
       
        public async Task<IActionResult> GetStudentswithoutpayments()
        {
            var result = await reportsRepository.studentswithoutpayments();
            var studentDTO = result.Select(s => new StudentDTO()
            {

                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                IsActive = s.IsActive,
                PhoneNumber = s.PhoneNumber
            }).ToList();
            return Ok(new ApiResponse<IEnumerable<StudentDTO>>
            {
                Success = true,
                Message = "Number of tracks and number of active students retrieved successfully.",
                Data = studentDTO
            });

        }
    }
}
