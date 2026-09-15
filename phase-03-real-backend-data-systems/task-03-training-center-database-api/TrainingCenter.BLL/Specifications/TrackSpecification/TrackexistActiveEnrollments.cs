using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class TrackexistActiveEnrollments:BaseSpecification<TrainingTrack>
    {
        public TrackexistActiveEnrollments(int id)
        {
            AddInclude(t => t.Enrollments);
            AddCriteria(t =>t.Id==id&& t.Enrollments.Any(e => e.Status == EnrollmentStatus.Active));
        }
    }

}
