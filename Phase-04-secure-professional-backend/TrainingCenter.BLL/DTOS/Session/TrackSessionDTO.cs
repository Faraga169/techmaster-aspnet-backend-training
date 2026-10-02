using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Session
{
    public class TrackSessionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public string? MeetingLink { get; set; } 
        public DateTime SessionDate { get; set; }
        public bool IsCompleted { get; set; }

        public int TrackId { get; set; }
        public string TrackName { get; set; } = null!;
    }
}
