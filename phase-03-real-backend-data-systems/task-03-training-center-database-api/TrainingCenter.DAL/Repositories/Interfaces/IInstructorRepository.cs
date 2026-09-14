using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Specifications;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IInstructorRepository:IGenericRepository<Instructor>
    {    
        public Task<IEnumerable<TrainingTrack>> GetTracksByInstructorId (ISpecification<TrainingTrack> spec);
    }
}
