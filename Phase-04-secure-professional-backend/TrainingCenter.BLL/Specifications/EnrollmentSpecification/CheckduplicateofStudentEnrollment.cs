using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.EnrollmentSpecification
{
    public class CheckduplicateofStudentEnrollment:BaseSpecification<Enrollment>
    {
        public CheckduplicateofStudentEnrollment(int studentid,int trackid)
        {
            AddCriteria(e => e.StudentId == studentid && e.TrainingTrackId == trackid);
        }
    }
}
