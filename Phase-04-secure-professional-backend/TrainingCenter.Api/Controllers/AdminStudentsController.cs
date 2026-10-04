using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.Services.Interface;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/admin/students")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminStudentsController(IEnrollmentService enrollmentService,IStudentService studentService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll(string? sreachbyName, bool? IsActive, int pagenumber = 1, int pagesize = 5)
        {

            var result = await studentService.GetAll(sreachbyName, IsActive, pagenumber, pagesize);

            return Ok(new ApiResponse<PaginatedResult<StudentDTO>>()
            {

                Success = true,
                Message = "Students retrieved successfully.",
                Data = result
            });
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await studentService.GetById(id);
            return Ok(new ApiResponse<StudentEnrollmentDTO>()
            {
                Success = true,
                Message = "Student with Enrollments",
                Data = result
            });
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDTO createStudentDTO)
        {
            var student = await studentService.Create(createStudentDTO);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, new ApiResponse<StudentDTO>
            {
                Success = true,
                Message = "Student created successfully.",
                Data = student
            });

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDTO updateStudentDTO)
        {
            

            var student = await studentService.Update(id,updateStudentDTO);

            return Ok(new ApiResponse<StudentDTO>
            {
                Success = true,
                Message = "Student updated successfully.",
                Data = student
            });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await studentService.Delete(id);
            return NoContent();


        }


        [HttpGet("{id}/enrollments")]
        public async Task<IActionResult> GetEnrollments(int id)
        {
            var result = await enrollmentService.GetEnrollmentsbyStudentId(id);

            return Ok(new ApiResponse<IEnumerable<EnrollmentDTO>>
            {
                Success = true,
                Message = "Student enrollment history retrieved successfully.",
                Data = result
            });
        }
    }
}
