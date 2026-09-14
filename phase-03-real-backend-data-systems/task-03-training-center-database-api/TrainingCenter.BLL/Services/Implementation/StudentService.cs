using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class StudentService(IUnitOfWork unitOfWork,IMapper mapper) : IStudentService
    {

        public async Task<IEnumerable<StudentDTO>> GetAll(string? searchbyName, bool? IsActive)
        {
            var StudentSpecification = new StudentBySearchNameorIsActiveSpecification(searchbyName, IsActive);
            var GetAllStudent = await unitOfWork.Repository<Student>().GetAll(StudentSpecification);
            var StudentsDTO = mapper.Map<IEnumerable<Student>,IEnumerable<StudentDTO>>(GetAllStudent);
            return StudentsDTO;
        }

        public async Task<StudentEnrollmentDTO> GetById(int id)
        {
            var StudentSpecification = new StudentByIdSpecification(id);
            var GetStudentEnrollment = await unitOfWork.Repository<Student>().GetById(StudentSpecification);
            if (GetStudentEnrollment is null)
                throw new BusinessException("Student is not found", 404);
            var StudentEnrollmentDTO = mapper.Map<Student,StudentEnrollmentDTO>(GetStudentEnrollment);
            return StudentEnrollmentDTO;

        }
        public async Task Create(CreateStudentDTO dto)
        {
            var spec = new StudentByEmailSpecification(dto.Email);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (existingStudent is not null)
                throw new BusinessException("Email already exists",400);

            var student = mapper.Map<Student>(dto);

            await unitOfWork.Repository<Student>().Create(student);

            await unitOfWork.CompleteChanges();
        }


        public async Task Update(UpdateStudentDTO dto)
        {
            var spec = new StudentByIdSpecification(dto.Id);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (existingStudent is  null)
                throw new BusinessException("Student not found", 404);

            var student = mapper.Map<Student>(dto);

            await unitOfWork.Repository<Student>().Update(student);

            await unitOfWork.CompleteChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var spec = new StudentByIdSpecification(id);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (existingStudent is null)
                throw new BusinessException("Student not found", 404);        

            await unitOfWork.Repository<Student>().Delete(id);
            await unitOfWork.CompleteChanges();

        }

        

      

       
    }
}
