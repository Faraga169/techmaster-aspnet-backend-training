using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.StudentSpecifications
{
    public class StudentByEmailSpecification:BaseSpecification<Student>
    {
        public StudentByEmailSpecification(string Email)
        {
            AddCriteria(s => s.Email == Email);
        }
    }
}
