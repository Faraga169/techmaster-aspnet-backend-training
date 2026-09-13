using Drill_01_DbContext___First_Migration.DTOS;

namespace Drill_01_DbContext___First_Migration.Services
{
    public interface ITrackService
    {
        public StudentwithEnrollmentDTO GetById(int id);
    }
}
