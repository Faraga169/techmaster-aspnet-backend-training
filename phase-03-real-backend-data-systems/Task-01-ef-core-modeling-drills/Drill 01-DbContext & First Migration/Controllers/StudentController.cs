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
        [HttpGet("{id}/tracks")]

        public IActionResult GetById(int id)
        {

            var result = studentService.GetById(id);
            return Ok(result);

        }

        [HttpGet("DeletedStudents")]
        public IActionResult GetAll()
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
        
            var student=await studentService.Create(createStudentDTO);
            return Ok(student);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateStudentDTO updateStudentDTO)
        {

            var student = await studentService.Update(updateStudentDTO);
            return Ok(student);
        }

    }
}
