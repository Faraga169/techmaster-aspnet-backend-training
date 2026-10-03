using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Session;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Interface;


namespace TrainingCenter.Api.Controllers
{
    [Route("api/instructor")]
    [ApiController]
    [Authorize(Roles = "Instructor")]
    public class InstructorController(IInstrcutorService instructorService,IReportService reportService,ITrackSession trackSession) : ControllerBase
    {
       
        [HttpGet("my-tracks")]
        public async Task<IActionResult> GetMyTracks()
        {
            var result = await instructorService.GetMyTracks();

            return Ok(new ApiResponse<IEnumerable<TrackDTO>>
            {
                Success = true,
                Message = "Your tracks retrieved successfully.",
                Data = result
            });
        }

      

                                  //   /api/instructor/tracks/{id}/sessions
        [HttpPost("tracks/{id}/sessions")]
        public async Task<ActionResult<ApiResponse<TrackSessionDTO>>> CreateSessionsbytrackid(int id,CreateSessionDTO createSessionDTO) {

            var result = await trackSession.Create(id, createSessionDTO);
            return Ok(new ApiResponse<TrackSessionDTO>()
            {

                Success = true,
                Message = "Instructor Create Track Session Successfully",
                Data = result
            });
        
        }

                                   //   /api/instructor/tracks/{id}/sessions
        [HttpPut("sessions/{id}")]
        public async Task<ActionResult<ApiResponse<TrackSessionDTO>>> updateSessionbyid(int id, UpdateTrackSessionDTO updateSessionDTO)
        {

            var result = await trackSession.Update(id, updateSessionDTO);
            return Ok(new ApiResponse<TrackSessionDTO>()
            {

                Success = true,
                Message = "Instructor update Track Session Successfully",
                Data = result
            });

        }

                                 //   /api/instructor/tracks/{id}/sessions
        [HttpPut("sessions/{id}/complete")]
        public async Task<ActionResult<ApiResponse<TrackSessionDTO>>> updateSessionstatus(int id)
        {

            var result = await trackSession.Complete(id);
            return Ok(new ApiResponse<TrackSessionDTO>()
            {

                Success = true,
                Message = "Instructor Update Status Track Session Successfully",
                Data = result
            });

        }

                                    //   /api/instructor/tracks/{id}/sessions
        [HttpGet("my-sessions")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TrackSessionDTO>>>> GetMySessions()
        {

            var result = await trackSession.GetAll();
            return Ok(new ApiResponse<IEnumerable<TrackSessionDTO>>()
            {

                Success = true,
                Message = "Instructor Track Sessions Retrieve Successfully",
                Data = result
            });

        }
    }
}
