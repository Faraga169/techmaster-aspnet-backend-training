using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class ApplicationUser:IdentityUser
    {

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateAt { get; set; }

        public DateTime? LastLoginAt { get; set; }


    }
}
