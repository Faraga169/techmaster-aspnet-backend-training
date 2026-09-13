using Drill_01_DbContext___First_Migration.DTOS;

namespace Drill_01_DbContext___First_Migration.Services
{
    public interface IInstructorService
    {
        public IEnumerable<GetAllInstructorwithtracksDTO> GetAll();

        public GetAllInstructorwithtracksDTO GetById(int id);
    }
}
