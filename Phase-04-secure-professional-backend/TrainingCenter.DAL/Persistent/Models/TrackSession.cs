using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class TrackSession:BaseEntity<int>
    {
        //SessionDate, Title, Description, MeetingLink, IsCompleted and CreatedByInstructorId.

     

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? MeetingLink { get; set; }

        public DateTime SessionDate { get; set; }

        public bool IsCompleted { get; set; }

        public int CreatedByInstructorId { get; set; }

        public Instructor CreatedByInstructor { get; set; } = null!;

        public TrainingTrack TrainingTrack { get; set; } = null!;

        public int TrackId { get; set; }
    }
}
