using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController(ITrackService trackService,IEnrollmentService enrollmentService) : ControllerBase
    {
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await trackService.Delete(id);

            return NoContent();
        }


        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var result =await enrollmentService.GetStudentsByTrackId(id);

            return Ok(new ApiResponse<IEnumerable<StudentDTO>>
            {
                Success = true,
                Message = "Track students retrieved successfully.",
                Data = result
            });
        }
    }
}
