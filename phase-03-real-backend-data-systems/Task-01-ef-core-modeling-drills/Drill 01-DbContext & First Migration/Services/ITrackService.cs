using Drill_01_DbContext___First_Migration.DTOS;

namespace Drill_01_DbContext___First_Migration.Services
{
    public interface ITrackService
    {

        public IEnumerable<TrackDTO> GetAll();
        public StudentwithEnrollmentDTO GetById(int id);
    }
}
