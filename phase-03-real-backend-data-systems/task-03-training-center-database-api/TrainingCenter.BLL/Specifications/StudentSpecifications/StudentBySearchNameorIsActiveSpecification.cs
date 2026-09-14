using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.StudentSpecifications
{
    public class StudentBySearchNameorIsActiveSpecification:BaseSpecification<Student>
    {
        public StudentBySearchNameorIsActiveSpecification(string?searchByName,bool?isActive)
        {
            if (!string.IsNullOrWhiteSpace(searchByName) && isActive.HasValue)
            {
                AddCriteria(s =>s.FullName.Contains(searchByName) && s.IsActive == isActive.Value);
            }
            else if (!string.IsNullOrWhiteSpace(searchByName))
            {
                AddCriteria(s =>s.FullName.Contains(searchByName));
            }
            else if (isActive.HasValue)
            {
                AddCriteria(s =>s.IsActive == isActive.Value);
            }
        }
    }
}
