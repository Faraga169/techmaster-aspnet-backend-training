using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Audit;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IActivityLogService
    {
        public Task<PaginatedResult<ActivityLog>> GetAll(string?userId,string?entityName,DateTime? From,DateTime? To,int pagesize=5,int pagenumber=1);

        public Task LogAsync(ActivityLog activityLog, string? userId = null,string? userRole = null);
    }
}
