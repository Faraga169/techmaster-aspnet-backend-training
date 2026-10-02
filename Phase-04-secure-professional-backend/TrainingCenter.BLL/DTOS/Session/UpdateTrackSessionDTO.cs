using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Session
{
    public class UpdateTrackSessionDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string MeetingLink { get; set; } = null!;
        public DateTime SessionDate { get; set; }
    }
}
