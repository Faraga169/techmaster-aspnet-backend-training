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


        [HttpGet]
        public IActionResult Get(string? name, string? email, string? trackName, bool? IsActive, int pagenumber = 1, int pagesize = 5)
        {

            var students = studentService.GetAll(name,  email,trackName, IsActive, pagenumber, pagesize);

            return Ok(students);

        }


        [HttpPost]
        public IActionResult Create(CreateStudentRequest createStudent) {

            var studentCreate = studentService.Create(createStudent);

            return Ok(studentCreate);

        }
    }
}
