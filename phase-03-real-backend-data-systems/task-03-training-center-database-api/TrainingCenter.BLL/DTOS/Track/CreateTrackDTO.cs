using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Track
{
    public class CreateTrackDTO
    {
        public string Title { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public TrackLevel Level { get; set; }

        [Range(1, 30, ErrorMessage = "The Capacity of Track must between 1 and 30")]
        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TrainingStatus Status { get; set; }

        public int InstructorId { get; set; }
    }
}
