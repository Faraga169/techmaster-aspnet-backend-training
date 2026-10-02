using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Session;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface ITrackSession
    {
        public Task<IEnumerable<TrackSessionDTO>> GetAll();

        Task<TrackSessionDTO> Create(int trackId,CreateSessionDTO createSessionDTO);

        Task<TrackSessionDTO> Update(int sessionId,UpdateTrackSessionDTO updateSessionDTO);

        Task<TrackSessionDTO> Complete(int sessionId);

        Task<IEnumerable<TrackSessionDTO>> GetMyStudentSessions();
    }
}
