using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.AuditLogSpecification
{
    public class AuditsbyUserIdorEntityNameorDateRangeSpecification:BaseSpecification<ActivityLog>
    {
        public AuditsbyUserIdorEntityNameorDateRangeSpecification(string? userId, string? entityName, DateTime? From, DateTime? To, int pagesize = 5, int pagenumber = 1)
        {
            AddCriteria(a =>
             (string.IsNullOrEmpty(userId) || a.UserId == userId) &&
             (string.IsNullOrEmpty(entityName) || a.EntityName == entityName) &&
             (!From.HasValue || a.CreatedAt >= From.Value) &&
             (!To.HasValue || a.CreatedAt <= To.Value)
         );

            ApplyPaging(pagenumber, pagesize);
        }
    }
}
