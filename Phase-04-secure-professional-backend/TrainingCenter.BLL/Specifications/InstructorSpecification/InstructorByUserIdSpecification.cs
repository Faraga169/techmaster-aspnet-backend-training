using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.InstructorSpecification
{
    public class InstructorByUserIdSpecification:BaseSpecification<Instructor>
    {
        public InstructorByUserIdSpecification(string userId)
        {
            AddCriteria(i => i.UserId == userId);
        }
    }
}
