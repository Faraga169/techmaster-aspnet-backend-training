using Drill_01_DbContext___First_Migration.DTOS;
using Drill_01_DbContext___First_Migration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drill_01_DbContext___First_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {


        [HttpGet("AllStudents")]
        public IActionResult GetAll()
        {

            var result = studentService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}/tracks")]

        public IActionResult GetById(int id)
        {

            var result = studentService.GetById(id);
            return Ok(result);

        }

        [HttpGet("{id}/StudentProfile")]
        public IActionResult GetStudentProfile(int id)
        {

            var result = studentService.GetStudentProfile(id);
            return Ok(result);

        }

        [HttpGet("DeletedStudents")]
        public IActionResult GetAllDeletedStudents()
        {

            var result = studentService.GetAllDeleted();
            return Ok(result);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            studentService.SoftDelete(id);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDTO createStudentDTO) { 
        
            await studentService.Create(createStudentDTO);
            return Created("","Student is Added Successfully");
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateStudentDTO updateStudentDTO)
        {

            await studentService.Update(updateStudentDTO);
            return Ok("Student is Updated Successfully");
        }

    }
}
