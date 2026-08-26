using System.Xml.Linq;
using StudentManagementAPI.DTOS;
using StudentManagementAPI.Exceptions;
using StudentManagementAPI.Models;
using StudentManagementAPI.Seeding;

namespace StudentManagementAPI.Services
{
    public class StudentService:IStudentService
    {
        public Student Create(CreateStudentRequest createStudent) {
            var result = StudentSeeding.Students.Any(s=>s.Email.Equals(createStudent.Email));

            if (result)
                throw new BusinessException("Email must be unique",400);

            var Student = new Student() {

                Id = Guid.NewGuid(),
                FullName= createStudent.FullName,
                Email = createStudent.Email,
                PhoneNumber = createStudent.PhoneNumber,
                TrackName = createStudent.TrackName,
                IsActive = createStudent.IsActive,
                LinkedInProfileUrl = createStudent.LinkedInProfileUrl,
                GitHubProfileUrl = createStudent.GitHubProfileUrl
            };

            StudentSeeding.Students.Add(Student);
            return Student;



        }


        public StudentResponse GetById(Guid id) {

            var student = StudentSeeding.Students.Find(s => s.Id == id);
            if (student is null) {

                throw new BusinessException("student not found", 404);
            }

            var studentResponseDto = new StudentResponse()
            {

                Id = student.Id,
                Email = student.Email,
                FullName = student.FullName,
                GitHubProfileUrl = student.GitHubProfileUrl,
                LinkedInProfileUrl = student.LinkedInProfileUrl,
                TrackName = student.TrackName,
                PhoneNumber = student.PhoneNumber
            };

            return studentResponseDto;

        }

        public PagedResultResponse GetAll(string?name,string?email,string?trackName,bool? IsActive,int pagenumber=1,int pagesize=5) {
            
           
            var students= StudentSeeding.Students;
            if (!string.IsNullOrWhiteSpace(trackName)) {

                 students = students.Where(s => s.TrackName.Equals(trackName, StringComparison.OrdinalIgnoreCase)).ToList();
               
            }
            if (IsActive is not null) {
                students = students.Where(s => s.IsActive==IsActive).ToList();
            }
            if (!string.IsNullOrWhiteSpace(name)) {
                students = students.Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(email)) {
                students = students.Where(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (pagesize <= 0) { 
            
                throw new BusinessException("Page size must be greater than 0",400);
            }

            if (pagenumber <= 0) {

                throw new BusinessException("Page number must be greater than 0", 400);

            }

            var TotalCount = students.Count();
            var numberofpages = (int)Math.Ceiling((decimal)TotalCount / pagesize);
            if (pagenumber > numberofpages && numberofpages>0)
            {
                throw new BusinessException($"Page number must be in range between 1 and {numberofpages}", 400);
            }

               
                students = students.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToList();
             

            var pagedResultDTO = new PagedResultResponse()
            {

                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalCount = TotalCount,
                TotalPages = numberofpages,
                Students = students.ToList(),
            };
            return pagedResultDTO;

        }

        public Student Update(Guid Id,UpdateStudentRequest updateStudent)
        {
           

            if (string.IsNullOrWhiteSpace(updateStudent.TrackName))
            {

                throw new BusinessException("Track Name is required", 400);

            }
           
            if (string.IsNullOrWhiteSpace(updateStudent.FullName))
            {
                throw new BusinessException("Full Name is required", 400);
            }

            if (string.IsNullOrWhiteSpace(updateStudent.Email))
            {
                throw new BusinessException("Email is required", 400);
            }

            if (string.IsNullOrWhiteSpace(updateStudent.PhoneNumber))
            {
                throw new BusinessException("Phone is required", 400);
            }
            var emailExists = StudentSeeding.Students.Any(s =>s.Email.Equals(updateStudent.Email, StringComparison.OrdinalIgnoreCase)&& s.Id != Id);

            if (emailExists)
            {
                throw new BusinessException("Email must be unique", 400);
            }

            var result = StudentSeeding.Students.Find(s => s.Id == Id);
            if (result is null)
                throw new BusinessException("Student not found", 404);



               result.FullName = updateStudent.FullName;
                result.Email = updateStudent.Email;
                result.PhoneNumber = updateStudent.PhoneNumber;
                result.TrackName = updateStudent.TrackName;
                result.IsActive = updateStudent.IsActive;
                result.LinkedInProfileUrl = updateStudent.LinkedInProfileUrl;
               result.GitHubProfileUrl = updateStudent.GitHubProfileUrl;
           

            return result;



        }



        public Student UpdateStatus(Guid Id,UpdateStudentStatusRequest updateStudentStatus)
        {


           
            var result = StudentSeeding.Students.Find(s => s.Id==Id);

            if (result is null)
            {
                throw new BusinessException("Student not found", 404);
            }

            result.IsActive = updateStudentStatus.IsActive;
          


            return result;



        }

        public StudentStatsResponse Stats()
        {

            var TotalStudents = StudentSeeding.Students.Count();

            var ActiveStudents = StudentSeeding.Students.Where(s => s.IsActive).Count();

            var InActiveStudents = StudentSeeding.Students.Where(s => !s.IsActive).Count();

            var CountBytrack = StudentSeeding.Students.GroupBy(s => s.TrackName).Select(s=>new TrackStatsResponse {TrackName=s.Key,Count=s.Count() }).ToList();


            var Result = new StudentStatsResponse()
            {

                TotalStudents = TotalStudents,
                ActiveStudents = ActiveStudents,
                InActiveStudents = InActiveStudents,
                CountByTrack = CountBytrack
            };
            


            return Result;



        }

    }
}
