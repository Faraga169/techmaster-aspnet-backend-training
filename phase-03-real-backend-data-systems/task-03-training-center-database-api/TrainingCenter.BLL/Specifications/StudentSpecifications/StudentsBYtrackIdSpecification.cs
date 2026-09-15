using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.StudentSpecifications
{
    public class StudentsBYtrackIdSpecification:BaseSpecification<Student>
    {
        public StudentsBYtrackIdSpecification(int trackid)
        {
            AddCriteria(s => s.Enrollments.Any(e => e.TrainingTrackId == trackid));
        }
    }
}
