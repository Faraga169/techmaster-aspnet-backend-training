using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Exceptions;

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

        public GetAllInstructorwithtracksDTO GetById(int id) {

            var Instructor= appContext.Instructors.Include(s => s.TrainingTracks).FirstOrDefault(s=>s.Id==id);
            if (Instructor is null)
                throw new BusinessException("Instructor not Found", 404);


            var GetInstructorswithtrackByIdDTO = new GetAllInstructorwithtracksDTO()
            {

                FullName = Instructor.FullName,
                Email = Instructor.Email,
                TracksName = Instructor.TrainingTracks.Where(t => t.InstructorId == Instructor.Id).Select(t => t.Name).ToList()
            };

            return GetInstructorswithtrackByIdDTO;
        }
    }
}
