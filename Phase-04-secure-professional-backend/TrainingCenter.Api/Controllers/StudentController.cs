using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService,IEnrollmentService enrollmentService,IPaymentService paymentService) : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string? sreachbyName, bool? IsActive, int pagenumber = 1, int pagesize = 5) {

            var result = await studentService.GetAll(sreachbyName,IsActive,pagenumber,pagesize);

            return Ok(new ApiResponse<PaginatedResult<StudentDTO>>()
            {

                Success = true,
                Message = "Students retrieved successfully.",
                Data = result
            });
        }

        [Authorize(Roles = "Student")]
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

        [Authorize(Roles ="Admin,Student")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            var result = await studentService.GetById(id);
            return Ok(new ApiResponse<StudentEnrollmentDTO>()
            {
                Success = true,
                Message = "Student with Enrollments",
                Data = result
            });
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDTO createStudentDTO)
        {
            var student=await studentService.Create(createStudentDTO);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, new ApiResponse<StudentDTO>
            {
                Success = true,
                Message = "Student created successfully.",
                Data = student
            });

        }

        [Authorize(Roles ="Admin,Student")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateStudentDTO updateStudentDTO)
        {
            updateStudentDTO.Id = id;

            var student = await studentService.Update(updateStudentDTO);

            return Ok(new ApiResponse<StudentDTO>
            {
                Success = true,
                Message = "Student updated successfully.",
                Data = student
            });
        }

        [Authorize(Roles = "Student")]
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


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await studentService.Delete(id);
            return NoContent();


        }

        [Authorize(Roles = "Admin,Student")]
        [HttpGet("{id}/enrollments")]
        public async Task<IActionResult> GetEnrollments(int id)
        {
            var result =await enrollmentService.GetEnrollmentsbyStudentId(id);

            return Ok(new ApiResponse<IEnumerable<EnrollmentDTO>>
            {
                Success = true,
                Message = "Student enrollment history retrieved successfully.",
                Data = result
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

        [Authorize(Roles = "Student")]
        [HttpPost("enrollment-request")]
        public async Task<IActionResult> Create(CreateEnrollDTO dto)
        {
            var enrollment = await enrollmentService.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = enrollment.Id },
                new ApiResponse<EnrollmentDTO>
                {
                    Success = true,
                    Message = "Student enrolled successfully.",
                    Data = enrollment
                });
        }

        [Authorize(Roles = "Student")]
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

    }
}
