using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Drill_01_DbContext___First_Migration.Models;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Exceptions;

namespace Drill_01_DbContext___First_Migration.Services
{
    public class StudentService(AppDbContext appContext) : IStudentService
    {
        public TrackwithEnrollmentDTO GetById(int id)
        {

            var Student = appContext.Enrollments.Include(e => e.Track).FirstOrDefault(s => s.StudentId == id);
            if (Student is null)
                throw new BusinessException("STUDENT not Found", 404);


            var GetTrackwithEnrollmentDTO = new TrackwithEnrollmentDTO()
            {
                TrackName = Student.Track.Name,

                EnrollmentDate = Student.EnrollmentDate,
                FinalGrade = Student.FinalGrade,
                Status = Student.Status.ToString()

            };

            return GetTrackwithEnrollmentDTO;
        }


        public IEnumerable<StudentsDTO> GetAllDeleted()
        {

            var students = appContext.Students.IgnoreQueryFilters().Where(s => s.IsDeleted).ToList();
            if (students.Count == 0)
                throw new BusinessException("Students not found", 404);

            var StudentsDto = students.Select(s => new StudentsDTO()
            {

                FullName = s.FullName,
                Email = s.Email
            });

            return StudentsDto.ToList();
        }

        public void SoftDelete(int id)
        {
            var student = appContext.Students.Find(id);

            if (student is null)
                throw new BusinessException("Student not found", 404);

            student.IsDeleted = true;
            student.DeletedAt = DateTime.UtcNow;
            student.IsActive = false;

            appContext.SaveChanges();
        }


        public async Task<int> Create(CreateStudentDTO createStudentDTO)
        {

            var Student = new Student()
            {

                FullName = createStudentDTO.FullName,
                Email = createStudentDTO.Email
            };
            appContext.Add(Student);
            return await appContext.SaveChangesAsync();
        }



        public async Task<int> Update(UpdateStudentDTO updateStudentDTO)
        {
            var student = await appContext.Students.FindAsync(updateStudentDTO.Id);

            if (student is null)
                throw new BusinessException("Student not found", 404);

            student.FullName = updateStudentDTO.FullName;
            student.Email = updateStudentDTO.Email;

            return await appContext.SaveChangesAsync();
        }

        public StudentProfileDTO GetStudentProfile(int id)
        {
           var Student= appContext.Students.Include(s=>s.StudentProfile).FirstOrDefault(s=>s.StudentProfile.StudentId==id);

            if(Student is  null)
                throw new BusinessException("Student profile not found", 404);

            var StudentProfileDTO = new StudentProfileDTO()
            {

                FullName = Student.FullName,
                NationalId = Student.StudentProfile.NationalId,
                Address = Student.StudentProfile.Address,
                DateOfBirth = Student.StudentProfile.DateOfBirth,
                EmergencyPhone = Student.StudentProfile.EmergencyPhone

            };

            return StudentProfileDTO;


        }

        public IEnumerable<StudentsDTO> GetAll()
        {
            var Students = appContext.Students.AsNoTracking().ToList();
            var StudentsDTO = Students.Select(s => new StudentsDTO()
            {

                FullName = s.FullName,
                Email = s.Email
            });

            return StudentsDTO.ToList();
        }
    }
}