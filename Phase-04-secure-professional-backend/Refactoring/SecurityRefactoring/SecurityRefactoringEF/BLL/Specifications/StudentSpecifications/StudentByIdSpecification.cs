using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.StudentSpecifications
{
    public class StudentByIdSpecification:BaseSpecification<Student>
    {
        public StudentByIdSpecification(int id)
        {
            AddInclude(s => s.Enrollments);
            AddCriteria(s => s.Id == id);
        }
    }
}
