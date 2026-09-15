using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.Services.Interface;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(string? sreachbyName, bool? IsActive, int pagenumber = 1, int pagesize = 5) {

            var result = await studentService.GetAll(sreachbyName,IsActive,pagenumber,pagesize);

            return Ok(new ApiResponse<PaginatedResult<StudentDTO>>()
            {

                Success = true,
                Message = "Student is Created Sucessfully!",
                Data = result
            });
        }


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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
     int id,
     UpdateStudentDTO updateStudentDTO)
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await studentService.Delete(id);
            return NoContent();


        }



    }
}
