using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class InstructorRepository(AppDbContext dbContext) : GenericRepository<Instructor>(dbContext),IInstructorRepository
    {
       
        public async Task<IEnumerable<TrainingTrack>> GetTracksByInstructorId(int id)
        {
            var TracksByInstructor = await dbContext.TrainingTracks.AsNoTracking().Where(t => t.InstructorId == id).ToListAsync();
            return TracksByInstructor;
        }
    }
}
