using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.DTOS.Session;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.Services.Interface;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/student")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class StudentController(IStudentService studentService,IEnrollmentService enrollmentService,IPaymentService paymentService,ITrackSession trackSession) : ControllerBase
    {
       

        [HttpGet("me")]
        public async Task<ActionResult<ApiResponse<StudentDTO>>> GetMyProfile()
        {
            var result = await studentService.GetMyProfile();

            return Ok(new ApiResponse<StudentDTO>
            {
                Success = true,
                Message = "Student profile retrieved successfully.",
                Data = result
            });
        }



      
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile(UpdateStudentDTO updateStudentDTO)
        {
            var student = await studentService.UpdateMyProfile(updateStudentDTO);

            return Ok(new ApiResponse<StudentDTO>
            {
                Success = true,
                Message = "Student profile updated successfully.",
                Data = student
            });
        }

       

        [Authorize(Roles = "Student")]
        [HttpGet("my-enrollments")]
        public async Task<IActionResult> GetEnrollments()
        {
            var result = await enrollmentService.GetMyEnrollments();

            return Ok(new ApiResponse<IEnumerable<EnrollmentDTO>>
            {
                Success = true,
                Message = "My enrollment history retrieved successfully.",
                Data = result
            });
        }


       
        [HttpPost("enrollment-request")]
        public async Task<IActionResult> Create(CreateEnrollDTO dto)
        {
            var enrollment = await enrollmentService.Create(dto);

            return CreatedAtAction(nameof(AdminStudentsController.GetById), new { id = enrollment.Id },
                new ApiResponse<EnrollmentDTO>
                {
                    Success = true,
                    Message = "Student enrolled successfully.",
                    Data = enrollment
                });
        }



       
        [HttpGet("my-payments")]
        public async Task<IActionResult> GetMyPayments()
        {
            var result = await paymentService.GetMyPayments();

            return Ok(new ApiResponse<IEnumerable<PaymentDTO>>
            {
                Success = true,
                Message = "My payment history retrieved successfully.",
                Data = result
            });
        }

                                   
        [HttpGet("my-sessions")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TrackSessionDTO>>>> GetMySessions()
        {

            var result = await trackSession.GetMyStudentSessions();
            return Ok(new ApiResponse<IEnumerable<TrackSessionDTO>>()
            {

                Success = true,
                Message = "Student Tracks Sessions Retrieve Successfully",
                Data = result
            });

        }
    }
}
