using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.EnrollmentSpecification
{
    public class StudentsBYtrackIdSpecification:BaseSpecification<Enrollment>
    {
        public StudentsBYtrackIdSpecification(int trackid)
        {
            AddInclude(e=>e.Student!);
            AddCriteria(e => e.TrainingTrackId == trackid);
        }
    }
}
