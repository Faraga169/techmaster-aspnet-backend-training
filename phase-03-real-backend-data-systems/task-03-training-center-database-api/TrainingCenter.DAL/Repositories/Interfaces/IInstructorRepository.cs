using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IInstructor
    {
        public Task<IEnumerable<Instructor>> GetAll();

        public Task<Instructor?> GetById(int id);

        public Task<int> Create(Instructor instructor);

        public Task<int> Update(Instructor instructor);

        public Task<IEnumerable<Instructor>> GetTracksByInstructorId (int id);
    }
}
