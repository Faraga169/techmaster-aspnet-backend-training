using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }

        public string Token { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; }

        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
    }
}
