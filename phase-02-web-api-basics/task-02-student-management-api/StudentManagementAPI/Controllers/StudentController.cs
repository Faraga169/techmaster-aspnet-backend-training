using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.DTOS;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentService studentService) : ControllerBase
    {
        public IActionResult Create(CreateStudentRequest createStudent) {

            var studentCreate = studentService.Create(createStudent);

            return Ok(studentCreate);

        }
    }
}
