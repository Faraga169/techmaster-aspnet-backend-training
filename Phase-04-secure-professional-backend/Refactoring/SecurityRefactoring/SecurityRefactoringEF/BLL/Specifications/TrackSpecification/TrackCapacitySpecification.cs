using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class TrackCapacitySpecification:BaseSpecification<TrainingTrack>
    {
        public TrackCapacitySpecification(int trackId)
        {
            AddCriteria(t =>t.Id == trackId &&t.Enrollments.Count(e => e.Status == EnrollmentStatus.Active) < t.Capacity
       );
        }
    }
}
