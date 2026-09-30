using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.InstructorSpecification
{
    public class InstructorbyIdspecification:BaseSpecification<Instructor>
    {
        public InstructorbyIdspecification(int id)
        {
            AddCriteria(i => i.Id == id);
        }
    }
}
