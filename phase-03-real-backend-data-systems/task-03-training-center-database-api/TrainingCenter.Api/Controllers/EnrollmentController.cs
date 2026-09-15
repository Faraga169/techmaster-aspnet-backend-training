using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController(IEnrollmentService enrollmentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(EnrollmentStatus? status,int? trackId, int? studentId, PaymentStatus? paymentStatus)
        {
            var result = await enrollmentService.GetAll(status,trackId,studentId,paymentStatus);

            return Ok(new ApiResponse<IEnumerable<EnrollmentDTO>>
            {
                Success = true,
                Message = "Enrollments retrieved successfully.",
                Data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await enrollmentService.GetById(id);

            return Ok(new ApiResponse<EnrollmentDetailsDTO>
            {
                Success = true,
                Message = "Enrollment details retrieved successfully.",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollDTO dto)
        {
            var enrollment = await enrollmentService.Create(dto);

            return CreatedAtAction(nameof(GetById),new { id = enrollment.Id },
                new ApiResponse<EnrollmentDTO>
                {
                    Success = true,
                    Message = "Student enrolled successfully.",
                    Data = enrollment
                });
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id,UpdateEnrollDTO dto)
        {
            dto.Id = id;

            var enrollment =await enrollmentService.Update(dto);

            return Ok(new ApiResponse<EnrollmentDTO>
            {
                Success = true,
                Message = "Enrollment status updated successfully.",
                Data = enrollment
            });
        }

        [HttpGet("/api/students/{id}/enrollments")]
        public async Task<IActionResult> GetStudentEnrollments(int id)
        {
            var result =await enrollmentService.GetEnrollmentsbyStudentId(id);

            return Ok(new ApiResponse<IEnumerable<EnrollmentDTO>>
            {
                Success = true,
                Message = "Student enrollment history retrieved successfully.",
                Data = result
            });
        }

        [HttpGet("/api/tracks/{id}/students")]
        public async Task<IActionResult> GetTrackStudents(int id)
        {
            var result =await enrollmentService.GetStudentsByTrackId(id);

            return Ok(new ApiResponse<IEnumerable<StudentDTO>>
            {
                Success = true,
                Message = "Track students retrieved successfully.",
                Data = result
            });
        }
    }
}
