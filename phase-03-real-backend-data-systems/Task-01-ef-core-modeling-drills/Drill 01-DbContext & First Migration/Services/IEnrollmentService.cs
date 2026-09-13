using Drill_01_DbContext___First_Migration.DTOS;

namespace Drill_01_DbContext___First_Migration.Services
{
    public interface IEnrollmentService
    {
        public IEnumerable<GetEnrollmentsDTO> GetAll();
    }
}
