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
    public class TrackRepository(AppDbContext dbContext):ITrackRepository
    {
        public async Task<IEnumerable<TrainingTrack>> GetAll()
        {
            var Tracks = await dbContext.TrainingTracks.AsNoTracking().ToListAsync();
            return Tracks;
        }


        public async Task<TrainingTrack?> GetById(int id)
        {
            var Track = await dbContext.TrainingTracks.FindAsync(id);
            return Track;
        }

        public async Task<int> Create(TrainingTrack track)
        {
            await dbContext.TrainingTracks.AddAsync(track);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<int> Update(TrainingTrack track)
        {
            dbContext.Update(track);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<bool> Delete(int id)
        {
            var Track = await dbContext.TrainingTracks.FindAsync(id);
            if (Track is null)
                return false;

            Track.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
