using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface ITrackRepository
    {
        public Task<IEnumerable<TrainingTrack>> GetAll();

        public Task<TrainingTrack?> GetById(int id);

        public Task<int> Create(TrainingTrack track);

        public Task<int> Update(TrainingTrack track);

        public Task<bool> Delete(int id);
    }
}
