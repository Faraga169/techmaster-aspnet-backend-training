using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.SessionSpecification
{
   public class GetSessionsByStudentIdSpecification:BaseSpecification<TrackSession>
    {
        public GetSessionsByStudentIdSpecification(int studentId)
        {
            AddCriteria(s => s.TrainingTrack.Enrollments.Any(e => e.StudentId == studentId));
        }
    }
}
