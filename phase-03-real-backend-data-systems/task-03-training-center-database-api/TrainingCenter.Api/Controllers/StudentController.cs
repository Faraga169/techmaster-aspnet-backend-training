using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
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
    }
}
