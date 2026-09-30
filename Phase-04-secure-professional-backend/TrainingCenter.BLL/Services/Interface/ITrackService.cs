using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface ITrackService
    {
        public Task<IEnumerable<TrackDTO>> GetAll(string? trackName, TrackLevel? trackLevel, TrainingStatus? trackStatus, int? instructorId);

        public Task<TrackDetailsDTO> GetById(int id);

        public Task<TrackDTO> Create(CreateTrackDTO track);

        public Task<TrackDTO> Update(UpdateTrackDTO track);

        public Task<bool> Delete(int id);
    }
}
