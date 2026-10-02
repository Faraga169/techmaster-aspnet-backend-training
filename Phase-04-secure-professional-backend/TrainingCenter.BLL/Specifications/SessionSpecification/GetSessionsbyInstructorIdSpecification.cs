using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.SessionSpecification
{
    public class GetSessionsbyInstructorIdSpecification:BaseSpecification<TrackSession>
    {
        public GetSessionsbyInstructorIdSpecification(int instructorId)
        {
            AddCriteria(s => s.CreatedByInstructorId == instructorId);
        }
    }
}
