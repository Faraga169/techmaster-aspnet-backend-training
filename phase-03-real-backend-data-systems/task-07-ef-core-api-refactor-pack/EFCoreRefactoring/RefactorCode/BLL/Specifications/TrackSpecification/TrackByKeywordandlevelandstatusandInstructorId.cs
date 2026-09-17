using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class TrackByKeywordandlevelandstatusandInstructorId:BaseSpecification<TrainingTrack>
    {
        public TrackByKeywordandlevelandstatusandInstructorId(string? trackName, TrackLevel? trackLevel, TrainingStatus? trackStatus, int? instructorId)
        {
            AddCriteria(t =>
     (string.IsNullOrWhiteSpace(trackName) || t.Title.Contains(trackName)) &&
     (!trackLevel.HasValue || t.Level == trackLevel.Value) &&
     (trackStatus.HasValue?t.Status == trackStatus.Value:t.Status==TrainingStatus.Active&&t.Status==TrainingStatus.Upcoming) &&
     (!instructorId.HasValue || t.InstructorId == instructorId.Value)
 );
        }
    }
}
