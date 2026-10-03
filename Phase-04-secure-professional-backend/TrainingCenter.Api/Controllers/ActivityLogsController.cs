using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ActivityLogsController(IActivityLogService activityLogService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginatedResult<ActivityLog>>>> GetAll(
            [FromQuery] string? userId,
            [FromQuery] string? entityName,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = await activityLogService.GetAll(
                userId,
                entityName,
                from,
                to,
                pageSize,
                pageNumber);

            return Ok(new ApiResponse<PaginatedResult<ActivityLog>>() { 
            
                Success= true,
                Message="Audit log is recorded successfully",
                Data=result

            });
        }
    }
}
