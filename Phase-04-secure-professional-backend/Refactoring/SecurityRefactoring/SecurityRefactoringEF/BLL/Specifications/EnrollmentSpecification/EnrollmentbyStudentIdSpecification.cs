using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.EnrollmentSpecification
{
    public class EnrollmentbyStudentIdSpecification:BaseSpecification<Enrollment>
    {
        public EnrollmentbyStudentIdSpecification(int studentid)
        {
            AddInclude(e => e.TrainingTrack!);
            AddInclude(e => e.Student!);
            AddCriteria(e => e.StudentId == studentid);
        }
    }
}
