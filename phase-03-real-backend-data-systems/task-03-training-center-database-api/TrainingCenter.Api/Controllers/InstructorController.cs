using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Implementation;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(InstructorService instructorService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await instructorService.GetAll();

            return Ok(new ApiResponse<IEnumerable<InstructorDTO>>
            {
                Success = true,
                Message = "Instructors retrieved successfully.",
                Data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await instructorService.GetById(id);

            return Ok(new ApiResponse<InstructorDetailsDTO>
            {
                Success = true,
                Message = "Instructor retrieved successfully.",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInstructorDTO dto)
        {
            var instructor = await instructorService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = instructor.Id },
                new ApiResponse<InstructorDTO>
                {
                    Success = true,
                    Message = "Instructor created successfully.",
                    Data = instructor
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, UpdateInstructorDTO dto)
        {
            dto.Id = id;

            var instructor = await instructorService.Update(dto);

            return Ok(new ApiResponse<InstructorDTO>
            {
                Success = true,
                Message = "Instructor updated successfully.",
                Data = instructor
            });
        }

        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetTracksByInstructorId(int id)
        {
            var result = await instructorService.GetTracksByInstructorId(id);

            return Ok(new ApiResponse<IEnumerable<TrackDTO>>
            {
                Success = true,
                Message = "Instructor tracks retrieved successfully.",
                Data = result
            });
        }
    }
}
