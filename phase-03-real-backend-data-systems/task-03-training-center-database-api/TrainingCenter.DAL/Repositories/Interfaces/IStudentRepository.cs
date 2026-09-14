using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public  Task<IEnumerable<Student>> GetAll();

        public Task<Student?> GetById(int id);

        public Task<int> Create(Student student);

        public Task<int> Update(Student student);

        public Task<bool> Delete(int id);

    }
}
