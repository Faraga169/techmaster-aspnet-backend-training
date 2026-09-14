using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using static Azure.Core.HttpHeader;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class Instructor:BaseEntity<int>
    {

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public string Specialization { get; set; } = null!;

        public string? Bio { get; set; }

        public ICollection<TrainingTrack> TrainingTracks { get; set; } = new HashSet<TrainingTrack>();

    }
}
