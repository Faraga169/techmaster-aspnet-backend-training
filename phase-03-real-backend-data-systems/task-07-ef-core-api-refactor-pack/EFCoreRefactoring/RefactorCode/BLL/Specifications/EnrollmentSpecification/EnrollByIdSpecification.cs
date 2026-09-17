using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.EnrollmentSpecification
{
    public class EnrollByIdSpecification:BaseSpecification<Enrollment>
    {
        public EnrollByIdSpecification(int id)
        {
            AddInclude(e => e.Student!);
            AddInclude(e => e.TrainingTrack!);
            AddInclude(e => e.Payments);
            AddCriteria(e => e.Id == id);
        }
    }
}
