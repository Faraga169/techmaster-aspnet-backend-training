using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.AuditLogSpecification;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;
using static System.Collections.Specialized.BitVector32;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class ActivityLogService(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor) : IActivityLogService
    {


        public async Task<PaginatedResult<ActivityLog>> GetAll(string? userId, string? entityName, DateTime? From, DateTime? To, int pagesize = 5, int pagenumber = 1)
        {
            if (pagenumber < 1)
                throw new BusinessException("Page number must be greater than 0", 400);

            if (pagesize < 1)
                throw new BusinessException("Page size must be greater than 0", 400);

            var AuditSpecification = new AuditsbyUserIdorEntityNameorDateRangeSpecification(userId, entityName, From, To,  pagesize, pagenumber);
            var totalCount = await unitOfWork.Repository<ActivityLog>().Count(AuditSpecification);
            var GetAllActivityLogs = await unitOfWork.Repository<ActivityLog>().GetAll(AuditSpecification);
            return new PaginatedResult<ActivityLog>
            {
                Items = GetAllActivityLogs,
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(
            totalCount / (double)pagesize)
            };
            }


             public async Task LogAsync(ActivityLog activityLog, string? userId = null,string? userRole = null)
        {
            var httpContext = contextAccessor.HttpContext;

            var currentuserId = httpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentuserRole = httpContext?.User.FindFirstValue(ClaimTypes.Role);

            var ipAddress = httpContext?.Connection.RemoteIpAddress?.ToString();

            var activityLogs = new ActivityLog
            {
                UserId = userId?? currentuserId,
                UserRole = userRole?? currentuserRole,
                Action = activityLog.Action,
                EntityName = activityLog.EntityName,
                EntityId = activityLog.EntityId,
                Description = activityLog.Description,
                CreatedAt = DateTime.UtcNow,
                IpAddress = ipAddress,
                Metadata = activityLog.Metadata
            };
            await unitOfWork.Repository<ActivityLog>().Create(activityLogs);
           
        }
    
    }
}
