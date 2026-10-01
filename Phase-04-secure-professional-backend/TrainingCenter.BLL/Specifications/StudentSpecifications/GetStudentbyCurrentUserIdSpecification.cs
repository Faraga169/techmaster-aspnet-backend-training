using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.StudentSpecifications
{
    public class GetStudentbyCurrentUserIdSpecification:BaseSpecification<Student>
    {
        public GetStudentbyCurrentUserIdSpecification(string id)
        {
            AddCriteria(s => s.UserId == id);
        }
    }
}
