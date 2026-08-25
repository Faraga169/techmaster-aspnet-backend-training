using StudentManagementAPI.DTOS;
using StudentManagementAPI.Models;
using StudentManagementAPI.Seeding;

namespace StudentManagementAPI.Services
{
    public class StudentService
    {
        public Student Create(CreateStudentRequest createStudent) {

            if (createStudent is null)
                throw new ArgumentNullException("createStudent is null");
            var result = StudentSeeding.Students().Any(s=>s.Email.Equals(createStudent.Email));

            if (result)
                throw new InvalidOperationException("Email must be unique");

            var Student = new Student() {

                Id = Guid.NewGuid(),
                Email = createStudent.Email,
                PhoneNumber = createStudent.PhoneNumber,
                TrackName = createStudent.TrackName,
                IsActive = createStudent.IsActive,
                LinkedInProfileUrl = createStudent.LinkedInProfileUrl,
                GitHubProfileUrl = createStudent.GitHubProfileUrl
            };

            StudentSeeding.Students().Add(Student);
            return Student;



        }
    }
}
