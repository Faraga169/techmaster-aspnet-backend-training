using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class TrainingTrack:BaseEntity<int>
    {
        //        TrainingTrackId PK
        //Title required
        //Code unique
        //Description
        //Level
        //Capacity
        //StartDate
        //EndDate
        //Status
        //InstructorId FK
        //CreatedAt UTC
        //IsDeleted

        public string Title { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public TrackLevel Level { get; set; }

        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TrainingStatus Status { get; set; } = TrainingStatus.Upcoming;

        public decimal Price { get; set; }

        public int InstructorId { get; set; }

        public Instructor? Instructor{ get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();



    }
}
