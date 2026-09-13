using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Exceptions;

namespace Drill_01_DbContext___First_Migration.Services
{
    public class TrackService(AppDbContext appContext):ITrackService
    {


        public IEnumerable<TrackDTO> GetAll()
        {
            var Tracks = appContext.Tracks.AsNoTracking().ToList();
            var TracksDTO = Tracks.Select(t => new TrackDTO()
            {

                Name = t.Name,
                Description = t.Description
            });

            return TracksDTO.ToList();
        }
        public StudentwithEnrollmentDTO GetById(int id)
        {

            var Track = appContext.Enrollments.Include(e=>e.Student).FirstOrDefault(s => s.TrackId == id);
            if (Track is null)
                throw new BusinessException("Track not Found", 404);


            var GetStudentwithEnrollmentDTO = new StudentwithEnrollmentDTO()
            {
                StudentName = Track.Student.FullName,
                EnrollmentDate = Track.EnrollmentDate,
                FinalGrade = Track.FinalGrade,
                Status = Track.Status.ToString()

            };

            return GetStudentwithEnrollmentDTO;
        }
    }
}
