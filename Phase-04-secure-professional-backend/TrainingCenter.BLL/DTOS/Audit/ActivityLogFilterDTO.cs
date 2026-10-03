using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Audit
{
    public class ActivityLogFilterDTO
    {
        public string? UserId { get; set; }

        public string? EntityName { get; set; }

        public DateOnly? From { get; set; }

        public DateOnly? To { get; set; }

        public int PageSize { get; set; } = 5;

        public int PageNumber { get; set; } = 1;
    }
}
