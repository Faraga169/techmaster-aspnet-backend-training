using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class AvailableTracksSpecification:BaseSpecification<TrainingTrack>
    {
        public AvailableTracksSpecification()
        {
            AddCriteria(t =>
                (t.Status == TrainingStatus.Active ||
                 t.Status == TrainingStatus.Upcoming) &&
                t.Capacity > t.Enrollments.Count(e =>
                    e.Status == EnrollmentStatus.Active));
        }
    }
}
