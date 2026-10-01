using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(IInstrcutorService instructorService,IReportService reportService) : ControllerBase
    {
        [Authorize(Roles ="Admin")]
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


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/assign-instructor")]
        public async Task<IActionResult> AssignInstructor(
    int id,
    [FromBody] AssignInstructorDTO dto)
        {
            await trackService.AssignInstructor(id, dto.InstructorId);

            return Ok(new
            {
                message = "Instructor assigned successfully."
            });
        }

        [Authorize(Roles ="Admin,Instructor")]
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

        [Authorize(Roles ="Admin")]
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

        [Authorize(Roles ="Admin")]
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

        [Authorize(Roles = "Admin,Instructor")]
        [HttpGet("tracks/{id}/progress")]
        public async Task<IActionResult> GetTrackLevelSummary(int id)
        {
            var result = await reportService.GetTrackLevelSummary(id);

            return Ok(new ApiResponse<TrackLevelSummary>
            {
                Success = true,
                Message = "Track level summary retrieved successfully.",
                Data = result
            });
        }

        [Authorize(Roles ="Admin")]
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
