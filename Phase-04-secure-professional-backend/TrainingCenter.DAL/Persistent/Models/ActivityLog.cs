using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class ActivityLog:BaseEntity<int>
    {
        //        - Id
        //- UserId
        //- UserRole
        //- Action
        //- EntityName
        //- EntityId
        //- Description
        //- CreatedAt
        //- IpAddress optional
        //-Metadata optional

        public string UserId { get; set; } = null!;

        public string UserRole { get; set; } = null!;

        public string Action { get; set; } = null!;

        public string EntityName { get; set; } = null!;

        public string EntityId { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? IpAddress { get; set; }

        public string? Metadata { get; set; }


    }
}
