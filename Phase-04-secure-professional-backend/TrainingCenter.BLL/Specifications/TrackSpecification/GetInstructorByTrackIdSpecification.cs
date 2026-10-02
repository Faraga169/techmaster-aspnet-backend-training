using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class GetInstructorByTrackIdSpecification:BaseSpecification<TrainingTrack>
    {
        public GetInstructorByTrackIdSpecification(int trackId)
        {
            AddCriteria(t => t.Id == trackId);
            AddInclude(t => t.Instructor);
        }
    }
}
