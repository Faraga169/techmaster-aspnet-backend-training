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

        public Instructor? Instructor { get; set; }

        public Student? Student { get; set; }


        public ICollection<RefreshToken> RefreshTokens { get; set; }= new List<RefreshToken>();
    }
}
