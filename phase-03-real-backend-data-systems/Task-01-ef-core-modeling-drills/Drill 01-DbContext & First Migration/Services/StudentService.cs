using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Exceptions;

namespace Drill_01_DbContext___First_Migration.Services
{
    public class StudentService(AppDbContext appContext):IStudentService
    {
        public TrackwithEnrollmentDTO GetById(int id)
        {

            var Student = appContext.Enrollments.Include(e => e.Track).FirstOrDefault(s => s.StudentId ==id);
            if (Student is null)
                throw new BusinessException("STUDENT not Found", 404);


            var GetTrackwithEnrollmentDTO = new TrackwithEnrollmentDTO()
            {
                TrackName=Student.Track.Name,
                
                EnrollmentDate = Student.EnrollmentDate,
                FinalGrade = Student.FinalGrade,
                Status = Student.Status.ToString()

            };

            return GetTrackwithEnrollmentDTO;
        }
    }
}
