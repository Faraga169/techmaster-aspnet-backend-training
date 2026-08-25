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


        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {

            var student = studentService.GetById(id);

            return Ok(student);

        }

        [HttpPost]
        public IActionResult Create(CreateStudentRequest createStudent) {

            var studentCreate = studentService.Create(createStudent);

            return CreatedAtAction(nameof(GetById),new { id=studentCreate.Id},studentCreate);

        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, UpdateStudentRequest updateStudent)
        {

            var studentUpdate = studentService.Update(Id,updateStudent);

            return Ok(studentUpdate);

        }

        [HttpPatch]
        public IActionResult Update(Guid Id, UpdateStudentStatusRequest updateStudentstatus)
        {

            var studentUpdate = studentService.UpdateStatus(Id, updateStudentstatus);

            return Ok(studentUpdate);

        }


        [HttpGet("Stats")]
        public IActionResult GetStats()
        {

            var students = studentService.Stats();

            return Ok(students);

        }

    }
}
