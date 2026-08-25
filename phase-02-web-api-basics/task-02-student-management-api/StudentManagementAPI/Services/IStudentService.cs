using StudentManagementAPI.DTOS;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public interface IStudentService
    {
        Student Create(CreateStudentRequest createStudent);

        StudentResponse GetById(Guid id);

        PagedResultResponse GetAll(string? name,string? email,  string? trackName,bool? isActive,int pageNumber = 1,int pageSize = 5);

        Student Update(Guid id,UpdateStudentRequest updateStudent);

        Student UpdateStatus(Guid id,UpdateStudentStatusRequest updateStudentStatus);

        StudentStatsResponse Stats();
    
}
}
