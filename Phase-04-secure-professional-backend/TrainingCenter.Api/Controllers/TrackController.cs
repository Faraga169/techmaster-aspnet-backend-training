using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController(ITrackService trackService,IEnrollmentService enrollmentService,IReportService reportService) : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string? keyword,TrackLevel? level,TrainingStatus? status,int? instructorId)
        {
            var result = await trackService.GetAll(keyword,level,status,instructorId);

            return Ok(new ApiResponse<IEnumerable<TrackDTO>>
            {
                Success = true,
                Message = "Tracks retrieved successfully.",
                Data = result
            });
        }

        [Authorize(Roles = "Student")]
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableTracks()
        {
            var result = await trackService.GetAvailableTracks();

            return Ok(new ApiResponse<IEnumerable<TrackDTO>>
            {
                Success = true,
                Message = "Available tracks retrieved successfully.",
                Data = result
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/assign-instructor")]
        public async Task<IActionResult> AssignInstructor(int id, [FromBody] AssignInstructorDTO dto)
        {
            await trackService.AssignInstructor(id, dto.InstructorId);

            return Ok(new 
            {
                Success = true,
                message = "Instructor assigned successfully."
            });
        }

        [Authorize(Roles ="Admin,Instructor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await trackService.GetById(id);
            

            return Ok(new ApiResponse<TrackDetailsDTO>
            {
                Success = true,
                Message = "Track retrieved successfully.",
                Data = result
            });
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTrackDTO dto)
        {
            var track = await trackService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = track.Id },
                new ApiResponse<TrackDTO>
                {
                    Success = true,
                    Message = "Track created successfully.",
                    Data = track
                });
        }

        [Authorize(Roles ="Admin,Instructor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTrackDTO dto)
        {
            dto.Id = id;

            var track = await trackService.Update(dto);

            return Ok(new ApiResponse<TrackDTO>
            {
                Success = true,
                Message = "Track updated successfully.",
                Data = track
            });
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await trackService.Delete(id);

            return NoContent();
        }

        [Authorize(Roles ="Admin,Instructor")]
        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var result =await enrollmentService.GetStudentsByTrackId(id);

            return Ok(new ApiResponse<IEnumerable<TrackStudentDto>>
            {
                Success = true,
                Message = "Track students retrieved successfully.",
                Data = result
            });
        }


        [Authorize(Roles = "Admin,Instructor")]
        [HttpGet("{id}/progress")]
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
    }
}
