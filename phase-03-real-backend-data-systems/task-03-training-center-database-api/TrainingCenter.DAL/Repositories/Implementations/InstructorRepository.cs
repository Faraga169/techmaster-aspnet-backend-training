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
    public class InstructorRepository(AppDbContext dbContext) : IInstructorRepository
    {

        public async Task<IEnumerable<Instructor>> GetAll()
        {
            var Instructors = await dbContext.Instructors.AsNoTracking().ToListAsync();
            return Instructors;
        }



        public async Task<Instructor?> GetById(int id)
        {
            var Instructor = await dbContext.Instructors.FindAsync(id);
            return Instructor;
        }


        public async Task<int> Create(Instructor instructor)
        {
            await dbContext.Instructors.AddAsync(instructor);
            return await dbContext.SaveChangesAsync();
        }


        public async Task<int> Update(Instructor instructor)
        {
            dbContext.Update(instructor);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainingTrack>> GetTracksByInstructorId(int id)
        {
            var TracksByInstructor = await dbContext.TrainingTracks.AsNoTracking().Where(i => i.Id == id).ToListAsync();
            return TracksByInstructor;
        }
    }
}
