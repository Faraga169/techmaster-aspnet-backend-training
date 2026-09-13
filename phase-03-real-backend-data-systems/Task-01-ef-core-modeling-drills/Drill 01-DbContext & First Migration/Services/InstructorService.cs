using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Microsoft.EntityFrameworkCore;

namespace Drill_01_DbContext___First_Migration.Services
{
    public class InstructorService(AppDbContext appContext):IInstructorService
    {
        public IEnumerable<GetAllInstructorwithtracksDTO> GetAll()
        {

            var Instructors = appContext.Instructors.Include(s => s.TrainingTracks).ToList();

            var GetAllInstructorswithtrackDTO = Instructors.Select(i => new GetAllInstructorwithtracksDTO()
            {

                FullName = i.FullName,
                Email = i.Email,
                TracksName = i.TrainingTracks.Where(t => t.InstructorId == i.Id).Select(t=>t.Name).ToList()
            });

            return GetAllInstructorswithtrackDTO;
        }
    }
}
