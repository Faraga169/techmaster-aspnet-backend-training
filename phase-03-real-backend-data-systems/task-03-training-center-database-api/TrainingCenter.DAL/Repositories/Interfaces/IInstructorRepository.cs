using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IInstructorRepository:IGenericRepository<Instructor>
    {    
        public Task<IEnumerable<TrainingTrack>> GetTracksByInstructorId (int id);
    }
}
