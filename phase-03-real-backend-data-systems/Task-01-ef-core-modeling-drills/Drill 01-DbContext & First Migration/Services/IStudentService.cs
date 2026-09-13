using Drill_01_DbContext___First_Migration.DTOS;

namespace Drill_01_DbContext___First_Migration.Services
{
    public interface IStudentService
    {
        public TrackwithEnrollmentDTO GetById(int id);

        public IEnumerable<StudentsDTO> GetAllDeleted();
        public void SoftDelete(int id);

        public Task<int> Create(CreateStudentDTO createStudentDTO);

        public  Task<int> Update(UpdateStudentDTO updateStudentDTO);
    }
}
